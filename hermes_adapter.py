from __future__ import annotations

import base64
import io
import json
import os
import queue
import re
import select
import shlex
import subprocess
import threading
import time
import traceback
from dataclasses import asdict, dataclass, field
from datetime import datetime
from http import HTTPStatus
from http.server import BaseHTTPRequestHandler, ThreadingHTTPServer
from pathlib import Path
from typing import Any
from urllib.parse import parse_qs, unquote, urlparse
from uuid import uuid4


DELIMITER = '|||END|||'
DEFAULT_SYSTEM_PROMPT = (
    '你现在作为 niuma 多 Agent 团队中的普通员工节点工作。'
    '你必须直接完成任务并给出可执行结果。'
    '当前调用是机器对机器，不要向用户反问；如果信息不足，请明确写出假设后继续。'
    '优先在给定工作目录内完成任务，输出简洁、明确、可交付。'
)


@dataclass
class HermesNodeConfig:
    port: int = 5060
    host: str = '127.0.0.1'
    workspace: str = str(Path(__file__).resolve().parent)
    hermes_bin: str = 'hermes'
    use_wsl: bool = False
    wsl_distribution: str | None = None
    hermes_profile: str = 'default'
    toolsets: list[str] = field(default_factory=list)
    system_prompt: str = DEFAULT_SYSTEM_PROMPT
    command_timeout_seconds: int = 1800
    heartbeat_timeout_seconds: int = 600
    state_path: str = str(Path(__file__).resolve().parent / 'hermes_node_state.json')

    @classmethod
    def load(cls, path: str | None = None) -> 'HermesNodeConfig':
        candidate = path or os.environ.get('HERMES_NODE_CONFIG')
        if candidate and Path(candidate).exists():
            with open(candidate, 'r', encoding='utf-8-sig') as fh:
                data = json.load(fh)
            return cls(**data)
        return cls()


@dataclass
class HistoryItem:
    role: str
    content: str
    timestamp: str = field(default_factory=lambda: datetime.now().strftime('%Y-%m-%d %H:%M:%S'))


@dataclass
class SessionState:
    is_working: bool = False
    current_action: str = 'Idle'
    role: str = '普通员工'
    history: list[HistoryItem] = field(default_factory=list)
    runs: list[dict[str, Any]] = field(default_factory=list)
    process: subprocess.Popen[str] | None = None
    last_error: str | None = None
    last_started_at: str | None = None
    last_finished_at: str | None = None
    lock: threading.RLock = field(default_factory=threading.RLock, repr=False)

    def clear(self) -> None:
        with self.lock:
            self.is_working = False
            self.current_action = 'Idle'
            self.role = '普通员工'
            self.history.clear()
            self.runs.clear()
            self.process = None
            self.last_error = None
            self.last_started_at = None
            self.last_finished_at = None


@dataclass
class ChatRequestPayload:
    message: str = ''
    modelIndex: int = 0
    sop: str | None = None
    caller: str | None = None
    taskId: str | None = None
    lineageContext: str | None = None
    attachments: list[dict[str, Any]] | None = None
    snapshotAuditPayload: dict[str, Any] | None = None


def encode_chunk(chunk_type: str, content: str) -> str:
    return json.dumps({'type': chunk_type, 'content': content}, ensure_ascii=False) + DELIMITER


def _strip_xml_text(xml_text: str) -> str:
    cleaned = re.sub(r'<[^>]+>', '\n', xml_text)
    cleaned = re.sub(r'\s+', ' ', cleaned)
    return cleaned.strip()


def _extract_docx_text(decoded_bytes: bytes) -> str:
    try:
        import zipfile
        with zipfile.ZipFile(io.BytesIO(decoded_bytes)) as zf:
            text_parts = []
            for name in ('word/document.xml', 'word/header1.xml', 'word/footer1.xml'):
                if name in zf.namelist():
                    text_parts.append(_strip_xml_text(zf.read(name).decode('utf-8', errors='replace')))
            return '\n'.join(part for part in text_parts if part).strip()
    except Exception:
        return ''


def _extract_xlsx_text(decoded_bytes: bytes) -> str:
    try:
        import zipfile
        with zipfile.ZipFile(io.BytesIO(decoded_bytes)) as zf:
            shared_strings = []
            if 'xl/sharedStrings.xml' in zf.namelist():
                shared_xml = zf.read('xl/sharedStrings.xml').decode('utf-8', errors='replace')
                shared_strings = [match.strip() for match in re.findall(r'<t[^>]*>(.*?)</t>', shared_xml, flags=re.S)]
            values = []
            for name in zf.namelist():
                if not name.startswith('xl/worksheets/') or not name.endswith('.xml'):
                    continue
                sheet_xml = zf.read(name).decode('utf-8', errors='replace')
                for cell_match in re.finditer(r'<c([^>]*)>(.*?)</c>', sheet_xml, flags=re.S):
                    attrs, body = cell_match.groups()
                    value_match = re.search(r'<v>(.*?)</v>', body, flags=re.S)
                    if not value_match:
                        continue
                    raw = value_match.group(1).strip()
                    if 't="s"' in attrs and raw.isdigit():
                        idx = int(raw)
                        if 0 <= idx < len(shared_strings):
                            values.append(shared_strings[idx])
                    else:
                        values.append(raw)
            return '\n'.join(v for v in values if v).strip()
    except Exception:
        return ''


def _extract_pdf_text(decoded_bytes: bytes) -> str:
    try:
        text = decoded_bytes.decode('utf-8', errors='replace')
    except Exception:
        text = decoded_bytes.decode('latin-1', errors='replace')
    matches = re.findall(r'\(([^()]*)\)\s*Tj', text)
    if matches:
        return '\n'.join(item.strip() for item in matches if item.strip())
    plain = re.sub(r'[^\w\u4e00-\u9fff\n\r\t .,:;!?()\-_/]+', ' ', text)
    plain = re.sub(r'\s+', ' ', plain).strip()
    return plain[:4000]


def _save_attachment_file(name: str, decoded_bytes: bytes, workspace: str | None) -> str:
    if not workspace:
        return ''
    attach_dir = Path(workspace) / 'hermes_uploads'
    attach_dir.mkdir(parents=True, exist_ok=True)
    safe_name = re.sub(r'[^A-Za-z0-9._-\u4e00-\u9fff]+', '_', name) or 'attachment.bin'
    target = attach_dir / safe_name
    target.write_bytes(decoded_bytes)
    return str(target)


def summarize_attachments_for_prompt(attachments: list[dict[str, Any]] | None, workspace: str | None = None) -> str:
    if not attachments:
        return '无附件。'

    summaries: list[str] = []
    for index, item in enumerate(attachments, start=1):
        if not isinstance(item, dict):
            continue
        name = str(item.get('name') or f'attachment-{index}')
        content_type = str(item.get('contentType') or 'application/octet-stream')
        raw_base64 = str(item.get('base64Data') or '')
        entry_lines = [f'附件 {index}：{name}', f'类型：{content_type}']

        decoded_bytes = b''
        if raw_base64:
            try:
                decoded_bytes = base64.b64decode(raw_base64, validate=False)
            except Exception:
                decoded_bytes = b''

        saved_path = _save_attachment_file(name, decoded_bytes, workspace) if decoded_bytes else ''
        if saved_path:
            entry_lines.append(f'已保存到本地文件：{saved_path}')

        decoded_text = ''
        lower_name = name.lower()
        if decoded_bytes:
            if content_type.startswith('text/') or any(lower_name.endswith(ext) for ext in ('.txt', '.md', '.json', '.csv', '.yml', '.yaml', '.xml', '.html', '.js', '.ts', '.py', '.cs', '.java', '.sql', '.log')):
                decoded_text = decoded_bytes.decode('utf-8', errors='replace').strip()
            elif lower_name.endswith('.docx'):
                decoded_text = _extract_docx_text(decoded_bytes)
            elif lower_name.endswith('.xlsx'):
                decoded_text = _extract_xlsx_text(decoded_bytes)
            elif lower_name.endswith('.pdf') or content_type == 'application/pdf':
                decoded_text = _extract_pdf_text(decoded_bytes)
            elif content_type.startswith('image/'):
                entry_lines.append('这是一个图片附件。请优先使用视觉/图像工具查看该本地文件。')
            else:
                entry_lines.append(f'大小：{len(decoded_bytes)} bytes')

        if decoded_text:
            if len(decoded_text) > 4000:
                decoded_text = decoded_text[:4000] + '\n...[附件内容已截断]'
            entry_lines.append('文本内容：')
            entry_lines.append(decoded_text)
        elif not content_type.startswith('image/') and decoded_bytes and not any(line.startswith('大小：') for line in entry_lines):
            entry_lines.append('该附件暂未提取出可读文本，请结合本地文件路径交给 Hermes 自行处理。')

        summaries.append('\n'.join(entry_lines))

    return '\n\n'.join(summaries) if summaries else '无附件。'


def _normalize_snapshot_audit_payload(payload: Any) -> dict[str, Any]:
    if isinstance(payload, str):
        try:
            payload = json.loads(payload)
        except Exception:
            return {}
    if not isinstance(payload, dict):
        return {}
    normalized = dict(payload)
    nested = normalized.get('automationPayload')
    if isinstance(nested, dict):
        merged = dict(nested)
        for key, value in normalized.items():
            if key != 'automationPayload' and key not in merged:
                merged[key] = value
        normalized = merged
    return normalized


def build_snapshot_audit_consumption(payload: Any) -> dict[str, Any]:
    normalized = _normalize_snapshot_audit_payload(payload)
    if not normalized:
        return {}

    parts = normalized.get('parts') if isinstance(normalized.get('parts'), dict) else {}
    fallback = normalized.get('fallbackPriority') if isinstance(normalized.get('fallbackPriority'), dict) else {}
    review_structure = normalized.get('reviewResolutionStructure') if isinstance(normalized.get('reviewResolutionStructure'), dict) else {}
    provenance = normalized.get('snapshotAuditProvenance') if isinstance(normalized.get('snapshotAuditProvenance'), dict) else {}

    contract = str(normalized.get('contract') or 'snapshot-audit/v1').strip() or 'snapshot-audit/v1'
    handler = str(parts.get('handler') or '').strip()
    route = str(parts.get('route') or '').strip()
    verdict = str(parts.get('verdict') or '').strip().lower()
    review_mode = str(fallback.get('reviewMode') or '').strip()
    review_actions = str(fallback.get('reviewActions') or '').strip()
    review_escalation_action = str(fallback.get('reviewEscalationAction') or '').strip()
    resolution_structure_review_actions = str(review_structure.get('resolutionStructureReviewActions') or '').strip()
    resolution_structure_review_resolution = str(review_structure.get('resolutionStructureReviewResolution') or '').strip()
    resolution_structure_outcome = str(review_structure.get('resolutionStructureOutcome') or '').strip()
    resolution_structure_default_outcome = str(review_structure.get('resolutionStructureDefaultOutcome') or '').strip()
    resolution_structure_escalation_gate = str(review_structure.get('resolutionStructureEscalationGate') or '').strip()

    outcome_tokens = [token.strip() for token in resolution_structure_outcome.split('|') if token.strip()]
    decision = 'wait'
    decision_label = '等待新的摘要轨迹'
    if verdict == 'review-first':
        if 'request-human-confirmation' in outcome_tokens or review_escalation_action == 'request-human-confirmation':
            decision = 'request-human-confirmation'
            decision_label = '先复核并请求人工确认'
        else:
            decision = 'review-first'
            decision_label = '先复核变化项'
    elif verdict == 'act-now':
        preferred = resolution_structure_default_outcome or ''
        if preferred == 'request-human-confirmation' or 'request-human-confirmation' in outcome_tokens and preferred == '':
            decision = 'request-human-confirmation'
            decision_label = '请求人工确认后执行'
        elif preferred == 'reuse-resolution-option-map' or 'reuse-resolution-option-map' in outcome_tokens and preferred == '':
            decision = 'reuse-resolution-option-map'
            decision_label = '沿用 resolution option map 执行'
        else:
            decision = 'act-compatible'
            decision_label = '按兼容策略直接执行'
    else:
        decision = 'wait'
        decision_label = '等待新的摘要轨迹'

    should_review_first = verdict == 'review-first'
    requires_human_confirmation = decision == 'request-human-confirmation'
    can_act_directly = decision == 'act-compatible'
    provenance_source = str(provenance.get('source') or '').strip() or 'control-plane'
    provenance_mode = str(provenance.get('mode') or decision or verdict or 'inherit').strip() or 'inherit'
    provenance_label = str(provenance.get('label') or '').strip()
    if not provenance_label:
        if provenance_mode == 'review-first':
            provenance_label = '用户手动切换为复核优先'
        elif provenance_mode == 'act-compatible':
            provenance_label = '用户手动切换为直接执行'
        elif provenance_source == 'worklog-run':
            provenance_label = '沿用工作日志中的 control-plane 决策'
        else:
            provenance_label = '沿用 control-plane 决策'

    if provenance_source == 'task-modal-manual' or provenance_mode in {'review-first', 'act-compatible'}:
        priority = 'manual-override'
        priority_label = '手动覆盖优先'
        priority_reason = '当前决策以任务面板中的手动决策为准，并覆盖继承来源。'
    elif provenance_source == 'worklog-run':
        priority = 'worklog-inherited'
        priority_label = '工作日志回填优先'
        priority_reason = '当前决策优先沿用最近一次工作日志回填的 control-plane 结果。'
    else:
        priority = 'control-plane-default'
        priority_label = '控制面默认优先'
        priority_reason = '当前决策沿用控制面默认策略，暂无更高优先级覆盖。'

    persisted_priority = normalized.get('snapshotAuditPriority') if isinstance(normalized.get('snapshotAuditPriority'), dict) else {}
    persisted_priority_value = str(persisted_priority.get('priority') or '').strip()
    if persisted_priority_value and persisted_priority_value != priority:
        conflict_type = 'priority-mismatch'
        conflict_label = '优先级冲突'
        conflict_severity = 'warning'
        conflict_severity_label = '警告'
        conflict_auto_handle = 'review-first'
        conflict_auto_handle_label = '转入复核优先'
        adopted_label = '采用手动覆盖结果' if priority == 'manual-override' else '采用工作日志回填结果' if priority == 'worklog-inherited' else '采用控制面默认结果'
        conflict_reason = '当前已按更高优先级来源覆盖原决策。'
        should_review = True
        review_hint = '建议复核当前 snapshot 决策来源是否一致。'
    elif provenance_source == 'worklog-run' and provenance_mode in {'review-first', 'act-compatible'}:
        conflict_type = 'source-mode-mismatch'
        conflict_label = '来源/模式不一致'
        conflict_severity = 'blocking'
        conflict_severity_label = '阻塞'
        conflict_auto_handle = 'request-human-confirmation'
        conflict_auto_handle_label = '请求人工确认'
        adopted_label = '采用工作日志回填结果'
        conflict_reason = '当前来源标记为工作日志回填，但模式表现为显式覆盖。'
        should_review = True
        review_hint = '建议复核当前 snapshot 决策来源是否一致。'
    else:
        conflict_type = 'none'
        conflict_label = '无冲突'
        conflict_severity = 'info'
        conflict_severity_label = '信息'
        conflict_auto_handle = 'continue-current-policy'
        conflict_auto_handle_label = '继续沿用当前策略'
        adopted_label = '采用手动覆盖结果' if priority == 'manual-override' else '采用工作日志回填结果' if priority == 'worklog-inherited' else '采用控制面默认结果'
        conflict_reason = '当前来源、模式与优先级一致。'
        should_review = False
        review_hint = '当前无需额外复核。'

    return {
        'contract': contract,
        'handler': handler,
        'route': route,
        'verdict': verdict or 'wait',
        'reviewMode': review_mode,
        'reviewActions': review_actions,
        'resolutionStructureReviewActions': resolution_structure_review_actions,
        'resolutionStructureReviewResolution': resolution_structure_review_resolution,
        'resolutionStructureOutcome': resolution_structure_outcome,
        'resolutionStructureDefaultOutcome': resolution_structure_default_outcome,
        'resolutionStructureEscalationGate': resolution_structure_escalation_gate,
        'decision': decision,
        'decisionLabel': decision_label,
        'shouldWait': decision == 'wait',
        'shouldReviewFirst': should_review_first,
        'requiresHumanConfirmation': requires_human_confirmation,
        'canActDirectly': can_act_directly,
        'snapshotAuditProvenance': {
            'source': provenance_source,
            'mode': provenance_mode,
            'label': provenance_label,
        },
        'snapshotAuditPriority': {
            'priority': priority,
            'priorityLabel': priority_label,
            'reason': priority_reason,
        },
        'snapshotAuditConflict': {
            'conflictType': conflict_type,
            'conflictLabel': conflict_label,
            'severity': conflict_severity,
            'severityLabel': conflict_severity_label,
            'autoHandle': conflict_auto_handle,
            'autoHandleLabel': conflict_auto_handle_label,
            'adoptedLabel': adopted_label,
            'reason': conflict_reason,
            'shouldReview': should_review,
            'reviewHint': review_hint,
        },
    }


def summarize_snapshot_audit_for_prompt(decision: dict[str, Any] | None) -> str:
    if not decision:
        return '无 snapshot-audit 自动化载荷。'
    label = str(decision.get('decisionLabel') or '等待新的摘要轨迹').strip()
    contract = str(decision.get('contract') or 'snapshot-audit/v1').strip() or 'snapshot-audit/v1'
    route = str(decision.get('route') or 'unknown-route').strip() or 'unknown-route'
    handler = str(decision.get('handler') or 'unknown-handler').strip() or 'unknown-handler'
    verdict = str(decision.get('verdict') or 'wait').strip() or 'wait'
    provenance = decision.get('snapshotAuditProvenance') if isinstance(decision.get('snapshotAuditProvenance'), dict) else {}
    provenance_source = str(provenance.get('source') or 'control-plane').strip() or 'control-plane'
    provenance_mode = str(provenance.get('mode') or decision.get('decision') or verdict or 'inherit').strip() or 'inherit'
    provenance_label = str(provenance.get('label') or '沿用 control-plane 决策').strip() or '沿用 control-plane 决策'
    priority = decision.get('snapshotAuditPriority') if isinstance(decision.get('snapshotAuditPriority'), dict) else {}
    priority_value = str(priority.get('priority') or '').strip()
    priority_label = str(priority.get('priorityLabel') or '').strip()
    priority_reason = str(priority.get('reason') or '').strip()
    if not priority_value:
        if provenance_source == 'task-modal-manual' or provenance_mode in {'review-first', 'act-compatible'}:
            priority_value = 'manual-override'
            priority_label = '手动覆盖优先'
            priority_reason = '当前决策以任务面板中的手动决策为准，并覆盖继承来源。'
        elif provenance_source == 'worklog-run':
            priority_value = 'worklog-inherited'
            priority_label = '工作日志回填优先'
            priority_reason = '当前决策优先沿用最近一次工作日志回填的 control-plane 结果。'
        else:
            priority_value = 'control-plane-default'
            priority_label = '控制面默认优先'
            priority_reason = '当前决策沿用控制面默认策略，暂无更高优先级覆盖。'
    conflict = decision.get('snapshotAuditConflict') if isinstance(decision.get('snapshotAuditConflict'), dict) else {}
    conflict_type = str(conflict.get('conflictType') or '').strip()
    conflict_adopted = str(conflict.get('adoptedLabel') or '').strip()
    conflict_review = bool(conflict.get('shouldReview'))
    conflict_severity = str(conflict.get('severity') or '').strip()
    conflict_auto_handle = str(conflict.get('autoHandle') or '').strip()
    if not conflict_type:
        if provenance_source == 'task-modal-manual' and decision.get('snapshotAuditPriority', {}).get('priority') == 'control-plane-default':
            conflict_type = 'priority-mismatch'
            conflict_adopted = '采用手动覆盖结果'
            conflict_review = True
            conflict_severity = 'warning'
            conflict_auto_handle = 'review-first'
        else:
            conflict_type = 'none'
            conflict_adopted = '采用控制面默认结果'
            conflict_review = False
            conflict_severity = 'info'
            conflict_auto_handle = 'continue-current-policy'
    if conflict_type == 'priority-mismatch':
        if provenance_source == 'task-modal-manual' or provenance_mode in {'review-first', 'act-compatible'}:
            priority_value = 'manual-override'
            priority_label = '手动覆盖优先'
            priority_reason = '当前决策以任务面板中的手动决策为准，并覆盖继承来源。'
        elif provenance_source == 'worklog-run':
            priority_value = 'worklog-inherited'
            priority_label = '工作日志回填优先'
            priority_reason = '当前决策优先沿用最近一次工作日志回填的 control-plane 结果。'
        else:
            priority_value = 'control-plane-default'
            priority_label = '控制面默认优先'
            priority_reason = '当前决策沿用控制面默认策略，暂无更高优先级覆盖。'
    return (
        f'控制面自动化载荷：{contract} / route={route} / handler={handler} / verdict={verdict} '
        f'/ 决策={label} / 来源={provenance_source} / 模式={provenance_mode} / 来源说明={provenance_label} '
        f'/ 优先级={priority_value} / 优先级说明={priority_label} / 覆盖原因={priority_reason} '
        f'/ 冲突={conflict_type} / 采用={conflict_adopted} / 建议复核={'true' if conflict_review else 'false'} '
        f'/ 冲突级别={conflict_severity} / 处理门槛={conflict_auto_handle}'
    )


def build_hermes_prompt(
    *,
    config: HermesNodeConfig,
    username: str,
    role: str,
    message: str,
    caller: str | None,
    sop: str | None,
    history: list[HistoryItem],
    attachment_context: str,
    lineage_context: str,
    snapshot_audit_context: str = '',
) -> str:
    history_lines: list[str] = []
    for item in history[-12:]:
        history_lines.append(f'[{item.timestamp}] {item.role}: {item.content}')

    prompt_sections = [
        config.system_prompt,
        f'员工名：{username}',
        f'岗位：{role or "普通员工"}',
        f'工作目录：{Path(config.workspace).resolve().as_posix()}',
        f'调用人：{caller or "ceo"}',
        f'SOP：{sop or "无"}',
        '任务目标链：',
        lineage_context or '无明确目标链，默认按公司目标继续执行。',
        '历史对话（最近优先保留上下文）：',
        '\n'.join(history_lines) if history_lines else '无历史对话。',
        '本次附件：',
        attachment_context or '无附件。',
        '控制面自动化载荷：',
        snapshot_audit_context or '无 snapshot-audit 自动化载荷。',
        '本次任务：',
        message.strip() or '（空任务）',
        '输出要求：直接给出工作结果；如果你进行了文件修改、命令执行或生成产物，请在结尾简要说明。',
    ]
    return '\n\n'.join(prompt_sections)


def classify_runtime_step_kind(text: str) -> str:
    clean = str(text or '').strip()
    lower = clean.lower()
    if not clean:
        return 'stdout'
    if any(keyword in clean for keyword in ('正在分析任务', '正在制定执行计划', '正在准备检索', '正在整理输出', '正在评估需求', '正在思考')):
        return 'thinking'
    if re.search(r'\b(?:调用|使用)\s+(?:browser|terminal|read_file|search_files|patch|write_file|execute_code|process|vision_analyze|delegate_task|todo|memory|cronjob|skill_[a-z_]+)\b', lower):
        return 'tool'
    if re.search(r'^(?:\$|>|PS\s|cmd>|bash\s+-lc|python3?\b|npm\b|pnpm\b|yarn\b|git\b|dotnet\b|curl\b|powershell(?:\.exe)?\b|node\b)', clean, flags=re.I):
        return 'command'
    if re.search(r'(?:开始写入文件|已写入文件|文件已更新|生成产物|写入文档|保存到)|(?:a/|b/|\./|/mnt/|[A-Za-z]:\\).+\.(?:md|txt|json|csv|yml|yaml|png|jpg|jpeg|gif|svg|pdf|docx|xlsx|cs|py|js|ts|html|css)', clean, flags=re.I):
        return 'file'
    return 'stdout'


class HermesNodeRuntime:
    def __init__(self, config: HermesNodeConfig):
        self.config = config
        self.sessions: dict[str, SessionState] = {}
        self.sessions_lock = threading.RLock()
        self.state_path = Path(self.config.state_path)
        self._load_state()

    def _session_to_dict(self, session: SessionState) -> dict[str, Any]:
        return {
            'is_working': session.is_working,
            'current_action': session.current_action,
            'role': session.role,
            'history': [asdict(item) for item in session.history],
            'runs': session.runs,
            'last_error': session.last_error,
            'last_started_at': session.last_started_at,
            'last_finished_at': session.last_finished_at,
        }

    def _save_state(self) -> None:
        with self.sessions_lock:
            payload = {
                'sessions': {
                    username: self._session_to_dict(session)
                    for username, session in self.sessions.items()
                }
            }
        self.state_path.parent.mkdir(parents=True, exist_ok=True)
        self.state_path.write_text(json.dumps(payload, ensure_ascii=False, indent=2), encoding='utf-8')

    def _load_state(self) -> None:
        if not self.state_path.exists():
            return
        try:
            payload = json.loads(self.state_path.read_text(encoding='utf-8'))
        except Exception:
            return

        sessions_data = payload.get('sessions', {}) if isinstance(payload, dict) else {}
        if not isinstance(sessions_data, dict):
            return

        with self.sessions_lock:
            for username, session_data in sessions_data.items():
                if not isinstance(session_data, dict):
                    continue
                session = SessionState(
                    is_working=False,
                    current_action=session_data.get('current_action') or 'Idle',
                    role=unquote(session_data.get('role') or '普通员工'),
                    history=[HistoryItem(**item) for item in session_data.get('history', []) if isinstance(item, dict)],
                    runs=[dict(run) for run in session_data.get('runs', []) if isinstance(run, dict)],
                    process=None,
                    last_error=session_data.get('last_error'),
                    last_started_at=session_data.get('last_started_at'),
                    last_finished_at=session_data.get('last_finished_at'),
                )
                for run in session.runs:
                    if run.get('role'):
                        run['role'] = unquote(str(run['role']))
                    if run.get('status') == 'running':
                        run['status'] = 'interrupted'
                        run['updatedAt'] = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
                        run['lastError'] = run.get('lastError') or 'Hermes 节点进程曾重启，运行记录已恢复。'
                        steps = run.get('steps') or []
                        if steps and isinstance(steps[-1], dict) and steps[-1].get('status') == 'running':
                            steps[-1]['status'] = 'interrupted'
                            steps[-1]['timestamp'] = run['updatedAt']
                            steps[-1]['error'] = run['lastError']
                if session.current_action == 'Hermes is working':
                    session.current_action = 'Recovered after restart'
                self.sessions[username] = session

    def _save_state_for_session(self, _username: str) -> None:
        self._save_state()

    @staticmethod
    def _now_string() -> str:
        return datetime.now().strftime('%Y-%m-%d %H:%M:%S')

    def _append_live_output(self, username: str, text: str) -> None:
        clean = text.strip()
        if not clean:
            return
        self._emit_progress_event(username, clean)

    def _append_run_step(self, username: str, *, kind: str, status: str, text: str, timestamp: str | None = None) -> None:
        clean = text.strip()
        if not clean:
            return
        session = self.get_session(username)
        with session.lock:
            if not session.runs:
                return
            run = session.runs[0]
            step_time = timestamp or self._now_string()
            run['updatedAt'] = step_time
            run.setdefault('steps', []).append({
                'kind': kind,
                'status': status,
                'timestamp': step_time,
                'toolResult': clean,
            })
            if len(run['steps']) > 200:
                preserved = run['steps'][:1]
                tail = run['steps'][-199:]
                run['steps'] = preserved + tail if preserved else tail
        self._save_state_for_session(username)

    def _emit_progress_event(self, username: str, text: str, *, status: str = 'running', timestamp: str | None = None) -> None:
        self._append_run_step(username, kind=classify_runtime_step_kind(text), status=status, text=text, timestamp=timestamp)

    def _seed_initial_progress_steps(self, username: str, run: dict[str, Any], task_text: str) -> None:
        timestamp = run.get('createdAt') or self._now_string()
        hints = [
            '正在分析任务',
            '正在制定执行计划',
            '正在准备检索资料与工具调用路径',
        ]
        path_match = re.search(r'(?:a/|b/|\./)?[A-Za-z0-9_./-]+\.(?:md|txt|json|csv|yml|yaml|png|jpg|jpeg|gif|svg|pdf|docx|xlsx|cs|py|js|ts|html|css)', task_text or '', flags=re.I)
        if path_match:
            hints.append(f'开始写入文件 {path_match.group(0)}')
        for hint in hints:
            self._emit_progress_event(username, hint, status='running', timestamp=timestamp)

    def _append_placeholder_heartbeat(self, username: str) -> None:
        session = self.get_session(username)
        with session.lock:
            if not session.runs:
                return
            run = session.runs[0]
            timestamp = self._now_string()
            run['updatedAt'] = timestamp
            run.setdefault('steps', []).append({
                'kind': 'heartbeat',
                'status': 'running',
                'timestamp': timestamp,
                'toolResult': '仍在处理中，请稍候…',
            })
            if len(run['steps']) > 200:
                preserved = run['steps'][:1]
                tail = run['steps'][-199:]
                run['steps'] = preserved + tail if preserved else tail
        self._save_state_for_session(username)

    def _mark_run_abnormal(self, username: str, reason: str) -> None:
        session = self.get_session(username)
        with session.lock:
            timestamp = self._now_string()
            session.is_working = False
            session.current_action = 'Error'
            session.process = None
            session.last_error = reason
            session.last_finished_at = timestamp
            if session.runs:
                run = session.runs[0]
                if run.get('status') == 'running':
                    run['status'] = 'timeout'
                    run['updatedAt'] = timestamp
                    run['lastError'] = reason
                    run['finalContent'] = run.get('finalContent') or f'Request failed: {reason}'
                    run.setdefault('steps', []).append({
                        'kind': 'watchdog',
                        'status': 'timeout',
                        'timestamp': timestamp,
                        'error': reason,
                        'toolResult': reason,
                    })
            session.history.append(HistoryItem(role='assistant', content=f'Request failed: {reason}', timestamp=timestamp))
        self._save_state_for_session(username)

    def _read_available_line(self, stream: Any, timeout_seconds: float) -> str | None:
        ready, _, _ = select.select([stream], [], [], timeout_seconds)
        if not ready:
            return None
        return stream.readline()

    def get_session(self, username: str) -> SessionState:
        with self.sessions_lock:
            if username not in self.sessions:
                self.sessions[username] = SessionState()
            return self.sessions[username]

    def run_chat(self, username: str, role: str, payload: ChatRequestPayload) -> str:
        session = self.get_session(username)
        started_at = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
        run = {
            'runId': uuid4().hex,
            'taskId': payload.taskId or None,
            'user': username,
            'role': role or session.role or '普通员工',
            'taskText': payload.message or '',
            'status': 'running',
            'createdAt': started_at,
            'updatedAt': started_at,
            'finalContent': '',
            'lastError': None,
            'provider': 'openai-codex',
            'model': self.config.hermes_profile or 'default',
            'inputTokens': 0,
            'outputTokens': 0,
            'estimatedCost': 0,
            'costCurrency': 'USD',
            'steps': [
                {
                    'kind': 'chat',
                    'status': 'running',
                    'timestamp': started_at,
                    'toolResult': 'Hermes 节点已接收任务并开始执行。',
                }
            ],
            'artifacts': [],
            'pendingApproval': None,
        }

        with session.lock:
            if session.is_working:
                return '该 Hermes 节点当前正在执行其他任务，请稍后再试。'
            session.is_working = True
            session.current_action = 'Running Hermes'
            session.role = role or session.role or '普通员工'
            session.last_error = None
            session.last_started_at = started_at
            session.history.append(HistoryItem(role='user', content=payload.message or ''))
            session.runs.insert(0, run)
            del session.runs[20:]
        self._seed_initial_progress_steps(username, run, payload.message or '')
        self._save_state_for_session(username)

        snapshot_audit_decision = build_snapshot_audit_consumption(payload.snapshotAuditPayload)
        if snapshot_audit_decision:
            run['snapshotAuditDecision'] = snapshot_audit_decision
            self._emit_progress_event(username, summarize_snapshot_audit_for_prompt(snapshot_audit_decision))
            self._save_state_for_session(username)
        attachment_context = summarize_attachments_for_prompt(payload.attachments, self.config.workspace)
        prompt = build_hermes_prompt(
            config=self.config,
            username=username,
            role=role,
            message=payload.message or '',
            caller=payload.caller,
            sop=payload.sop,
            history=session.history[:-1],
            attachment_context=attachment_context,
            lineage_context=payload.lineageContext or '',
            snapshot_audit_context=summarize_snapshot_audit_for_prompt(snapshot_audit_decision),
        )

        command = self._build_command(prompt)

        output_parts: list[str] = []
        process: subprocess.Popen[str] | None = None
        started = time.time()
        heartbeat_seconds = max(1, int(self.config.heartbeat_timeout_seconds))
        placeholder_interval = 10.0
        last_visible_output_at = started
        last_placeholder_at = started
        try:
            if os.name == 'nt' and self.config.use_wsl:
                completed = subprocess.run(
                    command,
                    cwd=str(Path(__file__).resolve().parent),
                    capture_output=True,
                    text=True,
                    encoding='utf-8',
                    errors='replace',
                    timeout=self.config.command_timeout_seconds if self.config.command_timeout_seconds > 0 else None,
                )
                result_text = '\n'.join(part for part in [completed.stdout, completed.stderr] if part).strip()
                if completed.returncode != 0:
                    raise RuntimeError(result_text or f'Hermes 退出码异常: {completed.returncode}')
                if not result_text:
                    result_text = 'Hermes 已执行完成，但没有返回任何文本输出。'
                with session.lock:
                    session.history.append(HistoryItem(role='assistant', content=result_text))
                    session.is_working = False
                    session.current_action = 'Idle'
                    session.process = None
                    session.last_finished_at = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
                    run['status'] = 'completed'
                    run['updatedAt'] = session.last_finished_at
                    run['finalContent'] = result_text
                    run['steps'][-1]['status'] = 'completed'
                    run['steps'][-1]['timestamp'] = session.last_finished_at
                    run['steps'][-1]['toolResult'] = result_text
                self._save_state_for_session(username)
                return result_text

            process = subprocess.Popen(
                command,
                cwd=self.config.workspace,
                stdout=subprocess.PIPE,
                stderr=subprocess.STDOUT,
                text=True,
                encoding='utf-8',
                errors='replace',
                bufsize=1,
            )
            with session.lock:
                session.process = process
                session.current_action = 'Hermes is working'
            self._emit_progress_event(username, '调用 terminal 工具执行 Hermes CLI')
            self._emit_progress_event(username, f'$ {" ".join(command)}')
            self._save_state_for_session(username)

            assert process.stdout is not None
            reader_queue: queue.Queue[str | None] | None = None
            if os.name == 'nt':
                reader_queue = queue.Queue()

                def _reader() -> None:
                    assert process.stdout is not None
                    for chunk in iter(process.stdout.readline, ''):
                        reader_queue.put(chunk)
                    reader_queue.put(None)

                threading.Thread(target=_reader, daemon=True).start()

            while True:
                if self.config.command_timeout_seconds > 0 and (time.time() - started) > self.config.command_timeout_seconds:
                    process.kill()
                    raise TimeoutError(f'Hermes 执行超时（>{self.config.command_timeout_seconds} 秒）')

                poll_timeout = min(placeholder_interval, heartbeat_seconds)
                if reader_queue is None:
                    line = self._read_available_line(process.stdout, poll_timeout)
                else:
                    try:
                        line = reader_queue.get(timeout=poll_timeout)
                    except queue.Empty:
                        line = None
                now = time.time()
                if line is None:
                    if process.poll() is not None:
                        break
                    if now - last_visible_output_at >= heartbeat_seconds:
                        reason = f'Hermes 执行心跳超时（>{heartbeat_seconds} 秒无输出）'
                        process.kill()
                        self._mark_run_abnormal(username, reason)
                        return f'Request failed: {reason}'
                    if now - last_placeholder_at >= placeholder_interval:
                        self._append_placeholder_heartbeat(username)
                        last_placeholder_at = now
                    continue

                if line:
                    output_parts.append(line)
                    self._append_live_output(username, line)
                    last_visible_output_at = now
                    last_placeholder_at = now
                elif process.poll() is not None:
                    break

            remaining = process.stdout.read()
            if remaining:
                output_parts.append(remaining)
                for chunk_line in remaining.splitlines():
                    self._append_live_output(username, chunk_line)

            exit_code = process.wait(timeout=5)
            result_text = ''.join(output_parts).strip()
            if exit_code != 0:
                raise RuntimeError(result_text or f'Hermes 退出码异常: {exit_code}')
            if not result_text:
                result_text = 'Hermes 已执行完成，但没有返回任何文本输出。'

            with session.lock:
                session.history.append(HistoryItem(role='assistant', content=result_text))
                session.is_working = False
                session.current_action = 'Idle'
                session.process = None
                session.last_finished_at = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
                run['status'] = 'completed'
                run['updatedAt'] = session.last_finished_at
                run['finalContent'] = result_text
                run['steps'][-1]['status'] = 'completed'
                run['steps'][-1]['timestamp'] = session.last_finished_at
                run['steps'][-1]['toolResult'] = result_text
            self._save_state_for_session(username)
            return result_text
        except Exception as exc:
            print('[HermesNode] run_chat failed:\n' + traceback.format_exc(), flush=True)
            with session.lock:
                session.is_working = False
                session.current_action = 'Error'
                session.process = None
                session.last_error = str(exc)
                session.last_finished_at = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
                session.history.append(HistoryItem(role='assistant', content=f'Request failed: {exc}'))
                run['status'] = 'failed'
                run['updatedAt'] = session.last_finished_at
                run['lastError'] = str(exc)
                run['finalContent'] = f'Request failed: {exc}'
                run['steps'][-1]['status'] = 'failed'
                run['steps'][-1]['timestamp'] = session.last_finished_at
                run['steps'][-1]['error'] = str(exc)
            self._save_state_for_session(username)
            return f'Request failed: {exc}'
        finally:
            if process is not None and process.poll() is None:
                process.kill()
            if process is not None and process.stdout is not None:
                try:
                    process.stdout.close()
                except Exception:
                    pass

    def cancel(self, username: str) -> dict[str, str]:
        session = self.get_session(username)
        with session.lock:
            if session.process and session.process.poll() is None:
                session.process.kill()
                session.is_working = False
                session.current_action = 'Cancelled'
                session.process = None
                session.last_finished_at = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
                session.history.append(HistoryItem(role='assistant', content='Task cancelled.'))
                if session.runs:
                    run = session.runs[0]
                    if run.get('status') == 'running':
                        run['status'] = 'cancelled'
                        run['updatedAt'] = session.last_finished_at
                        run['lastError'] = 'Task cancelled by user.'
                        steps = run.get('steps') or []
                        if steps and isinstance(steps[-1], dict):
                            steps[-1]['status'] = 'cancelled'
                            steps[-1]['timestamp'] = session.last_finished_at
                            steps[-1]['error'] = 'Task cancelled by user.'
            else:
                session.current_action = 'Idle'
        self._save_state_for_session(username)
        return {'status': 'cancelled'}

    def _build_command(self, prompt: str) -> list[str]:
        base_command = [self.config.hermes_bin, 'chat', '-q', prompt, '-Q', '--profile', self.config.hermes_profile]
        if self.config.toolsets:
            base_command.extend(['-t', ','.join(self.config.toolsets)])
        if not self.config.use_wsl:
            return base_command

        shell_parts: list[str] = []
        if self.config.workspace:
            shell_parts.append(f'cd {shlex.quote(self.config.workspace)}')
        shell_parts.append(shlex.join(base_command))
        shell_command = ' && '.join(shell_parts)
        command = ['wsl.exe']
        if self.config.wsl_distribution:
            command.extend(['-d', self.config.wsl_distribution])
        command.extend(['bash', '-lc', shell_command])
        return command

    def clear(self, username: str) -> dict[str, str]:
        self.get_session(username).clear()
        self._save_state_for_session(username)
        return {'status': 'cleared'}

    def status_payload(self, username: str) -> dict[str, Any]:
        session = self.get_session(username)
        with session.lock:
            return {
                'isWorking': session.is_working,
                'currentAction': session.current_action if session.is_working else (session.current_action or 'Idle'),
                'lastError': session.last_error,
                'lastStartedAt': session.last_started_at,
                'lastFinishedAt': session.last_finished_at,
            }

    def history_payload(self, username: str) -> list[dict[str, Any]]:
        session = self.get_session(username)
        with session.lock:
            return [asdict(item) for item in session.history]

    def agent_profile_payload(self, username: str) -> dict[str, Any]:
        session = self.get_session(username)
        with session.lock:
            memory_items = [
                {
                    'date': item.timestamp,
                    'content': item.content,
                }
                for item in session.history[-6:]
                if item.content.strip()
            ][-3:]
            tool_names = self.config.toolsets or ['terminal', 'file', 'search']
            capabilities = list(dict.fromkeys(tool_names + (['attachments', 'vision'] if 'vision' not in tool_names else ['attachments'])))
            return {
                'user': username,
                'adapterType': 'hermes',
                'role': session.role or '普通员工',
                'workspace': str(Path(self.config.workspace).resolve()),
                'identity': (
                    f'# IDENTITY.md\n\n'
                    f'- Name: {username}\n'
                    f'- Role: {session.role or "普通员工"}\n'
                    f'- Workspace: {Path(self.config.workspace).resolve()}\n'
                    f'- Mode: 作为 niuma 团队中的 Hermes 员工节点执行任务。\n'
                ),
                'capabilities': capabilities,
                'supports': {
                    'approvals': True,
                    'runs': True,
                    'history': True,
                    'attachments': True,
                    'vision': True,
                },
                'tools': [
                    {
                        'name': name,
                        'label': name,
                        'requiresApproval': False,
                    }
                    for name in tool_names
                ],
                'recentMemory': memory_items,
                'budgetMonthly': 0,
                'budgetUsed': 0,
                'reportsTo': '',
                'health': {
                    'status': 'running' if session.is_working else 'healthy',
                    'source': 'hermes',
                    'message': session.current_action or 'Idle',
                    'lastSeenAt': session.last_finished_at or session.last_started_at or ''
                },
            }

    def agent_runs_payload(self, username: str) -> list[dict[str, Any]]:
        session = self.get_session(username)
        with session.lock:
            return [dict(run) for run in session.runs]

    def agent_run_payload(self, username: str, run_id: str) -> dict[str, Any] | None:
        session = self.get_session(username)
        with session.lock:
            for run in session.runs:
                if run.get('runId') == run_id:
                    return dict(run)
        return None


class HermesNodeHandler(BaseHTTPRequestHandler):
    runtime: HermesNodeRuntime | None = None
    server_version = 'HermesNode/0.1'

    def do_OPTIONS(self) -> None:
        self.send_response(HTTPStatus.NO_CONTENT)
        self._write_cors_headers()
        self.end_headers()

    def do_GET(self) -> None:
        parsed = urlparse(self.path)
        if parsed.path == '/':
            self._write_text(HTTPStatus.OK, 'Hermes niuma worker node is running.')
            return
        if parsed.path == '/api/status':
            self._write_json(HTTPStatus.OK, self._runtime().status_payload(self._request_user(parsed)))
            return
        if parsed.path in ('/api/config', '/api/models'):
            config = self._runtime().config
            self._write_json(HTTPStatus.OK, {
                'Models': [
                    {
                        'Model': f'Hermes Agent ({config.hermes_profile or "default"})',
                        'Provider': 'hermes',
                        'EndpointId': config.hermes_profile or 'default',
                        'Version': 'cli',
                    }
                ]
            })
            return
        if parsed.path == '/api/history':
            self._write_json(HTTPStatus.OK, self._runtime().history_payload(self._request_user(parsed)))
            return
        if parsed.path == '/api/agent/profile':
            self._write_json(HTTPStatus.OK, self._runtime().agent_profile_payload(self._request_user(parsed)))
            return
        if parsed.path == '/api/agent/runs':
            self._write_json(HTTPStatus.OK, self._runtime().agent_runs_payload(self._request_user(parsed)))
            return
        if parsed.path == '/api/agent/run':
            username = self._request_user(parsed)
            run_id = self._query_value(parsed, 'id')
            run = self._runtime().agent_run_payload(username, run_id)
            if run is None:
                self._write_json(HTTPStatus.NOT_FOUND, {'error': 'Run not found'})
                return
            self._write_json(HTTPStatus.OK, run)
            return
        self._write_json(HTTPStatus.NOT_FOUND, {'error': 'Not found'})

    def do_POST(self) -> None:
        if self.path == '/api/chat':
            self._handle_chat()
            return
        if self.path == '/api/clear':
            self._write_json(HTTPStatus.OK, self._runtime().clear(self._username()))
            return
        if self.path == '/api/cancel':
            self._write_json(HTTPStatus.OK, self._runtime().cancel(self._username()))
            return
        self._write_json(HTTPStatus.NOT_FOUND, {'error': 'Not found'})

    def log_message(self, fmt: str, *args: Any) -> None:
        return

    def _handle_chat(self) -> None:
        payload = self._read_json_body()
        request = ChatRequestPayload(**payload)
        username = self._username()
        role = unquote(self.headers.get('X-Role', '')).strip()
        result = self._runtime().run_chat(username, role, request)
        self._write_text(HTTPStatus.OK, encode_chunk('final', result), content_type='text/plain; charset=utf-8')

    def _runtime(self) -> HermesNodeRuntime:
        if self.runtime is None:
            raise RuntimeError('Hermes runtime not configured')
        return self.runtime

    def _username(self) -> str:
        raw = self.headers.get('X-Username', 'ceo')
        decoded = unquote(raw)
        return decoded.strip() or 'ceo'

    def _request_user(self, parsed: Any | None = None) -> str:
        query_user = self._query_value(parsed or urlparse(self.path), 'user')
        return query_user or self._username()

    @staticmethod
    def _query_value(parsed: Any, key: str) -> str:
        values = parse_qs(parsed.query).get(key, [''])
        return unquote(values[0]).strip()

    def _read_json_body(self) -> dict[str, Any]:
        length = int(self.headers.get('Content-Length', '0') or '0')
        raw = self.rfile.read(length) if length > 0 else b'{}'
        if not raw:
            return {}
        return json.loads(raw.decode('utf-8'))

    def _write_cors_headers(self) -> None:
        self.send_header('Access-Control-Allow-Origin', '*')
        self.send_header('Access-Control-Allow-Headers', 'Content-Type, X-Username, X-Team-Url, X-Role')
        self.send_header('Access-Control-Allow-Methods', 'GET, POST, OPTIONS')

    def _write_json(self, status: HTTPStatus, payload: Any) -> None:
        data = json.dumps(payload, ensure_ascii=False).encode('utf-8')
        self.send_response(status)
        self._write_cors_headers()
        self.send_header('Content-Type', 'application/json; charset=utf-8')
        self.send_header('Content-Length', str(len(data)))
        self.end_headers()
        self.wfile.write(data)

    def _write_text(self, status: HTTPStatus, text: str, content_type: str = 'text/plain; charset=utf-8') -> None:
        data = text.encode('utf-8')
        self.send_response(status)
        self._write_cors_headers()
        self.send_header('Content-Type', content_type)
        self.send_header('Content-Length', str(len(data)))
        self.end_headers()
        self.wfile.write(data)


def create_server(config: HermesNodeConfig) -> ThreadingHTTPServer:
    runtime = HermesNodeRuntime(config)
    HermesNodeHandler.runtime = runtime
    return ThreadingHTTPServer((config.host, config.port), HermesNodeHandler)


def main() -> None:
    config = HermesNodeConfig.load()
    server = create_server(config)
    print(f'[HermesNode] Listening on http://{config.host}:{config.port}/ workspace={Path(config.workspace).resolve()}')
    server.serve_forever()


if __name__ == '__main__':
    main()

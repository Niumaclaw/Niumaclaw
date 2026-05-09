from __future__ import annotations

import argparse
import json
import os
import re
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
AGENT_NAME = '猫咪咪'
ADAPTER_TYPE = 'catmeme'


def now() -> str:
    return datetime.now().strftime('%Y-%m-%d %H:%M:%S')


def slug_time() -> str:
    return datetime.now().strftime('%Y%m%d_%H%M%S')


def encode_chunk(chunk_type: str, content: str) -> str:
    return json.dumps({'type': chunk_type, 'content': content}, ensure_ascii=False) + DELIMITER


@dataclass
class CatMimiConfig:
    host: str = '127.0.0.1'
    port: int = 5077
    workspace: str = str(Path(__file__).resolve().parents[2])
    asset_dir: str = str(Path(__file__).resolve().parent / 'assets')
    output_dir: str = str(Path(__file__).resolve().parent / 'outputs')
    font_path: str = '/mnt/c/Windows/Fonts/msyhbd.ttc'
    fonts_dir: str = '/mnt/c/Windows/Fonts'
    default_duration: int = 60
    default_fps: int = 30
    role_clip_seconds: dict[str, int] = field(default_factory=lambda: {'boss': 180, 'me': 75, 'planner': 210})
    state_path: str = str(Path(__file__).resolve().parent / 'cat_mimi_state.json')

    @classmethod
    def load(cls, path: str | None = None) -> 'CatMimiConfig':
        candidate = path or os.environ.get('CAT_MIMI_CONFIG')
        if candidate and Path(candidate).exists():
            data = json.loads(Path(candidate).read_text(encoding='utf-8-sig'))
            return cls(**data)
        return cls()


@dataclass
class HistoryItem:
    role: str
    content: str
    timestamp: str = field(default_factory=now)


@dataclass
class SessionState:
    is_working: bool = False
    current_action: str = 'Idle'
    role: str = '猫meme视频生成师'
    history: list[HistoryItem] = field(default_factory=list)
    runs: list[dict[str, Any]] = field(default_factory=list)
    last_error: str | None = None
    last_started_at: str | None = None
    last_finished_at: str | None = None
    lock: threading.RLock = field(default_factory=threading.RLock, repr=False)

    def clear(self) -> None:
        with self.lock:
            self.is_working = False
            self.current_action = 'Idle'
            self.history.clear()
            self.runs.clear()
            self.last_error = None
            self.last_started_at = None
            self.last_finished_at = None


class CatMimiRuntime:
    def __init__(self, config: CatMimiConfig):
        self.config = config
        self.sessions: dict[str, SessionState] = {}
        self.lock = threading.RLock()
        Path(config.output_dir).mkdir(parents=True, exist_ok=True)
        Path(config.asset_dir).mkdir(parents=True, exist_ok=True)
        self._load_state()

    def _load_state(self) -> None:
        path = Path(self.config.state_path)
        if not path.exists():
            return
        try:
            raw = json.loads(path.read_text(encoding='utf-8'))
            for username, data in raw.get('sessions', {}).items():
                session = SessionState()
                session.is_working = False
                session.current_action = 'Idle'
                session.role = data.get('role') or session.role
                session.history = [HistoryItem(**item) for item in data.get('history', []) if isinstance(item, dict)]
                session.runs = data.get('runs', []) if isinstance(data.get('runs'), list) else []
                for run in session.runs:
                    if run.get('status') == 'running':
                        run['status'] = 'interrupted'
                        run['updatedAt'] = now()
                        run['lastError'] = 'Agent restarted while this run was active.'
                session.last_error = data.get('last_error')
                session.last_started_at = data.get('last_started_at')
                session.last_finished_at = data.get('last_finished_at')
                self.sessions[username] = session
        except Exception:
            print('[CatMimi] failed to load state:\n' + traceback.format_exc(), flush=True)

    def _save_state(self) -> None:
        try:
            serializable: dict[str, Any] = {'sessions': {}}
            for username, session in self.sessions.items():
                with session.lock:
                    serializable['sessions'][username] = {
                        'role': session.role,
                        'history': [asdict(item) for item in session.history[-80:]],
                        'runs': session.runs[:30],
                        'last_error': session.last_error,
                        'last_started_at': session.last_started_at,
                        'last_finished_at': session.last_finished_at,
                    }
            Path(self.config.state_path).write_text(json.dumps(serializable, ensure_ascii=False, indent=2), encoding='utf-8')
        except Exception:
            print('[CatMimi] failed to save state:\n' + traceback.format_exc(), flush=True)

    def get_session(self, username: str) -> SessionState:
        key = username.strip() or AGENT_NAME
        with self.lock:
            if key not in self.sessions:
                self.sessions[key] = SessionState()
            return self.sessions[key]

    def _new_run(self, message: str) -> dict[str, Any]:
        ts = now()
        return {
            'runId': str(uuid4()),
            'status': 'running',
            'task': message,
            'createdAt': ts,
            'updatedAt': ts,
            'adapterType': ADAPTER_TYPE,
            'steps': [],
            'artifacts': [],
            'finalContent': '',
        }

    def _append_step(self, run: dict[str, Any], kind: str, text: str, status: str = 'running', **extra: Any) -> None:
        step = {
            'id': str(uuid4()),
            'kind': kind,
            'status': status,
            'timestamp': now(),
            'toolResult': text,
        }
        step.update(extra)
        run.setdefault('steps', []).append(step)
        run['updatedAt'] = step['timestamp']
        if len(run['steps']) > 200:
            run['steps'] = run['steps'][-200:]
        self._save_state()

    def _read_body_message(self, payload: dict[str, Any]) -> str:
        msg = str(payload.get('message') or '').strip()
        return msg or '生成一个 60 秒低成本土味办公室猫 meme 视频，使用动态猫素材和原生抽象音频。'

    def run_chat(self, username: str, role: str, payload: dict[str, Any]) -> str:
        session = self.get_session(username)
        message = self._read_body_message(payload)
        run = self._new_run(message)
        with session.lock:
            session.role = role or '猫meme视频生成师'
            session.is_working = True
            session.current_action = '正在生成猫 meme 视频'
            session.last_started_at = now()
            session.last_error = None
            session.history.append(HistoryItem(role='user', content=message))
            session.runs.insert(0, run)
        self._save_state()

        try:
            self._append_step(run, 'chat', '收到任务，猫咪咪开始制作土味动态猫 meme 视频。')
            artifacts = self.generate_video(run, message)
            result = self._build_result(artifacts)
            with session.lock:
                session.is_working = False
                session.current_action = 'Idle'
                session.last_finished_at = now()
                session.history.append(HistoryItem(role='assistant', content=result))
                run['status'] = 'completed'
                run['updatedAt'] = session.last_finished_at
                run['finalContent'] = result
                run['artifacts'] = artifacts
            self._append_step(run, 'chat', '视频生成完成。', 'completed')
            self._save_state()
            return result
        except Exception as exc:
            err = f'猫咪咪生成失败：{exc}'
            with session.lock:
                session.is_working = False
                session.current_action = 'Error'
                session.last_error = str(exc)
                session.last_finished_at = now()
                session.history.append(HistoryItem(role='assistant', content=err))
                run['status'] = 'failed'
                run['updatedAt'] = session.last_finished_at
                run['lastError'] = str(exc)
                run['finalContent'] = err
            self._append_step(run, 'error', traceback.format_exc(), 'failed', error=str(exc))
            self._save_state()
            return err

    def _asset(self, name: str) -> str:
        return str(Path(self.config.asset_dir) / name)

    def _ensure_assets(self) -> tuple[str, str]:
        video = self._asset('cat_dynamic_source.f100026.mp4')
        audio = self._asset('cat_dynamic_source.f30280.m4a')
        missing = [p for p in (video, audio) if not Path(p).exists()]
        if missing:
            raise FileNotFoundError('缺少动态猫素材：' + '，'.join(missing))
        return video, audio

    def generate_video(self, run: dict[str, Any], message: str) -> list[dict[str, Any]]:
        video, audio = self._ensure_assets()
        out_dir = Path(self.config.output_dir) / f'cat_mimi_{slug_time()}'
        out_dir.mkdir(parents=True, exist_ok=True)
        ass_path = out_dir / 'cat_mimi.ass'
        filter_path = out_dir / 'cat_mimi_filter.ffgraph'
        output_path = out_dir / '猫咪咪_土味动态猫meme_B站版.mp4'
        preview_path = out_dir / 'preview_6s.jpg'
        montage_path = out_dir / 'montage.jpg'

        ass_path.write_text(self._build_ass(), encoding='utf-8')
        filter_path.write_text(self._build_filtergraph(str(ass_path)), encoding='utf-8')
        self._append_step(run, 'file', f'已生成字幕和滤镜脚本：{ass_path}\n{filter_path}')

        clips = self.config.role_clip_seconds
        cmd = [
            'ffmpeg', '-y', '-loglevel', 'error',
            '-f', 'lavfi', '-i', f'color=c=0xD3C2A3:s=1920x1080:r={self.config.default_fps}:d={self.config.default_duration}',
            '-ss', f"00:{clips.get('boss', 180)//60:02d}:{clips.get('boss', 180)%60:02d}", '-i', video,
            '-ss', f"00:{clips.get('me', 75)//60:02d}:{clips.get('me', 75)%60:02d}", '-i', video,
            '-ss', f"00:{clips.get('planner', 210)//60:02d}:{clips.get('planner', 210)%60:02d}", '-i', video,
            '-i', audio,
            '-filter_complex_script', str(filter_path),
            '-map', '[vout]', '-map', '4:a', '-t', str(self.config.default_duration),
            '-c:v', 'libx264', '-preset', 'medium', '-crf', '20', '-pix_fmt', 'yuv420p',
            '-c:a', 'aac', '-b:a', '160k', '-movflags', '+faststart', str(output_path),
        ]
        self._append_step(run, 'command', '开始调用 ffmpeg 合成视频。\n' + ' '.join(cmd[:8]) + ' ...')
        started = time.time()
        proc = subprocess.run(cmd, cwd=self.config.workspace, capture_output=True, text=True, encoding='utf-8', errors='replace', timeout=900)
        elapsed = time.time() - started
        if proc.returncode != 0:
            raise RuntimeError((proc.stderr or proc.stdout or 'ffmpeg failed').strip())
        self._append_step(run, 'command', f'ffmpeg 合成完成，耗时 {elapsed:.1f}s。', 'completed')

        self._run_quiet(['ffmpeg', '-y', '-loglevel', 'error', '-ss', '00:00:06', '-i', str(output_path), '-frames:v', '1', str(preview_path)], run, '抽取 6 秒预览帧')
        self._run_quiet(['ffmpeg', '-y', '-loglevel', 'error', '-i', str(output_path), '-vf', 'fps=1/10,scale=480:-1,tile=3x2', '-frames:v', '1', str(montage_path)], run, '生成 3x2 蒙太奇预览')
        probe = subprocess.run([
            'ffprobe', '-v', 'error', '-show_entries', 'stream=index,codec_type,width,height,r_frame_rate,duration', '-show_entries', 'format=duration,size', '-of', 'json', str(output_path)
        ], capture_output=True, text=True, encoding='utf-8', errors='replace', timeout=60)
        self._append_step(run, 'stdout', 'ffprobe 验证：\n' + (probe.stdout or '').strip(), 'completed')

        return [
            {'path': str(output_path), 'label': 'B站可发 MP4 成片', 'kind': 'video'},
            {'path': str(preview_path), 'label': '预览帧', 'kind': 'image'},
            {'path': str(montage_path), 'label': '蒙太奇检查图', 'kind': 'image'},
            {'path': str(ass_path), 'label': 'ASS 字幕脚本', 'kind': 'subtitle'},
            {'path': str(filter_path), 'label': 'ffmpeg 滤镜脚本', 'kind': 'script'},
        ]

    def _run_quiet(self, cmd: list[str], run: dict[str, Any], label: str) -> None:
        proc = subprocess.run(cmd, cwd=self.config.workspace, capture_output=True, text=True, encoding='utf-8', errors='replace', timeout=120)
        if proc.returncode != 0:
            raise RuntimeError(f'{label}失败：{proc.stderr or proc.stdout}')
        self._append_step(run, 'command', label + '完成。', 'completed')

    def _build_result(self, artifacts: list[dict[str, Any]]) -> str:
        video = artifacts[0]['path']
        preview = artifacts[1]['path']
        montage = artifacts[2]['path']
        return (
            '猫咪咪已完成猫 meme 视频生成。\n\n'
            f'成片：{video}\n'
            f'预览帧：{preview}\n'
            f'蒙太奇：{montage}\n\n'
            '规格：1920x1080 / 16:9 / 30fps / 60秒 / H.264 + AAC。\n'
            '风格：低成本土味客厅/办公室背景、动态猫绿幕素材、原生抽象音频、无旁白、无水印、无左上角文件名。'
        )

    def _build_ass(self) -> str:
        return r'''[Script Info]
ScriptType: v4.00+
PlayResX: 1920
PlayResY: 1080
WrapStyle: 0
ScaledBorderAndShadow: yes

[V4+ Styles]
Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding
Style: Dialog,Microsoft YaHei,70,&H00FFFFFF,&H000000FF,&H00000000,&H90000000,1,0,0,0,100,100,0,0,1,8,1,2,90,90,82,1
Style: SmallDialog,Microsoft YaHei,60,&H00FFFFFF,&H000000FF,&H00000000,&H90000000,1,0,0,0,100,100,0,0,1,7,1,2,90,90,82,1
Style: Card,Microsoft YaHei,86,&H00FFFFFF,&H000000FF,&H00000000,&H00000000,1,0,0,0,100,100,0,0,1,5,0,5,120,120,40,1
Style: EndCard,Microsoft YaHei,76,&H00FFF85A,&H000000FF,&H00000000,&H00000000,1,0,0,0,100,100,0,0,1,6,0,5,120,120,40,1

[Events]
Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text
Dialogue: 0,0:00:00.00,0:00:02.60,Card,,0,0,0,,00后运营刚上岗
Dialogue: 0,0:00:02.60,0:00:05.00,Card,,0,0,0,,老板甩来千万KPI
Dialogue: 0,0:00:05.00,0:00:08.50,Dialog,,0,0,0,,那个创业大赛的运营方案\N什么时候给我做出来啊？
Dialogue: 0,0:00:08.50,0:00:12.00,Dialog,,0,0,0,,老板，全网千万曝光\N我月薪三千扛不住啊！
Dialogue: 0,0:00:12.00,0:00:15.00,Dialog,,0,0,0,,招你进来不就干这个的吗？\N你不干，有的是人干。
Dialogue: 0,0:00:15.00,0:00:16.30,Card,,0,0,0,,猫猫沉默了
Dialogue: 0,0:00:16.30,0:00:18.40,Dialog,,0,0,0,,……
Dialogue: 0,0:00:18.40,0:00:21.50,Dialog,,0,0,0,,别慌，听我的话术发\N流量稳了！
Dialogue: 0,0:00:21.50,0:00:24.00,Dialog,,0,0,0,,好嘞！\N那参赛门槛是什么？
Dialogue: 0,0:00:24.00,0:00:27.80,SmallDialog,,0,0,0,,找一些牛马来给公司做项目\N能当牛做马就行。
Dialogue: 0,0:00:27.80,0:00:30.00,Dialog,,0,0,0,,啊？？？\N这样不好吧！
Dialogue: 0,0:00:30.00,0:00:30.90,Card,,0,0,0,,重来一遍
Dialogue: 0,0:00:30.90,0:00:35.60,SmallDialog,,0,0,0,,不看出身、不看背景\N只看想法够不够新颖\N执行力够不够强。
Dialogue: 0,0:00:35.60,0:00:38.00,Dialog,,0,0,0,,行，那参赛有哪些奖励呢？
Dialogue: 0,0:00:38.00,0:00:41.50,SmallDialog,,0,0,0,,说白了都是帮公司引流\N涨知名度的牛马罢了。
Dialogue: 0,0:00:41.50,0:00:44.00,Dialog,,0,0,0,,这话发出去直接凉\N不能这么写！
Dialogue: 0,0:00:44.00,0:00:45.00,Card,,0,0,0,,官方话术上线
Dialogue: 0,0:00:45.00,0:00:49.30,SmallDialog,,0,0,0,,免费项目曝光 + 导师指导\N丰厚奖金 + 资源对接
Dialogue: 0,0:00:49.30,0:00:53.50,SmallDialog,,0,0,0,,平台孵化，帮想法落地\N全程零成本，稳赚不亏。
Dialogue: 0,0:00:53.50,0:00:56.00,Dialog,,0,0,0,,……行吧，记住了……
Dialogue: 0,0:00:56.00,0:01:00.00,EndCard,,0,0,0,,家人们，这波宣发成功吗？\N关注牛马运营日常～
'''

    def _build_filtergraph(self, ass_path: str) -> str:
        fp = self.config.font_path
        fonts_dir = self.config.fonts_dir
        safe_ass = ass_path.replace('\\', '/')
        return f'''[0:v]
drawbox=x=0:y=0:w=1920:h=610:color=0xD3C2A3@1:t=fill,
drawbox=x=0:y=610:w=1920:h=470:color=0x8F765A@1:t=fill,
drawbox=x=0:y=600:w=1920:h=18:color=0x4A3524@1:t=fill,
drawbox=x=72:y=86:w=430:h=300:color=0xB7D0D8@1:t=fill,
drawbox=x=95:y=112:w=384:h=250:color=0xE8F3EF@1:t=fill,
drawbox=x=286:y=112:w=8:h=250:color=0x7B6040@1:t=fill,
drawbox=x=95:y=232:w=384:h=8:color=0x7B6040@1:t=fill,
drawbox=x=620:y=86:w=430:h=230:color=0xEFE2B6@1:t=fill,
drawbox=x=645:y=112:w=380:h=180:color=0xFFF4CA@1:t=fill,
drawbox=x=1240:y=82:w=455:h=270:color=0xEFE2B6@1:t=fill,
drawbox=x=1265:y=110:w=405:h=215:color=0xFFF4CA@1:t=fill,
drawtext=fontfile={fp}:text='创业大赛':x=700:y=155:fontsize=44:fontcolor=0xA62F22,
drawtext=fontfile={fp}:text='千万曝光':x=1350:y=145:fontsize=44:fontcolor=0xA62F22,
drawtext=fontfile={fp}:text='KPI':x=1438:y=220:fontsize=54:fontcolor=0xA62F22,
drawbox=x=95:y=520:w=510:h=210:color=0x7E4E35@1:t=fill,
drawbox=x=130:y=555:w=440:h=145:color=0x9B6445@1:t=fill,
drawbox=x=1310:y=520:w=500:h=210:color=0x7E4E35@1:t=fill,
drawbox=x=1345:y=555:w=430:h=145:color=0x9B6445@1:t=fill,
drawbox=x=510:y=650:w=910:h=160:color=0x86532F@1:t=fill,
drawbox=x=590:y=805:w=70:h=245:color=0x50301F@1:t=fill,
drawbox=x=1260:y=805:w=70:h=245:color=0x50301F@1:t=fill,
drawbox=x=820:y=505:w=280:h=160:color=0x2C3540@1:t=fill,
drawbox=x=780:y=665:w=360:h=30:color=0x20262D@1:t=fill,
drawbox=x=1160:y=538:w=220:h=96:color=0xFFF0A8@1:t=fill,
drawtext=fontfile={fp}:text='方案未完成':x=1182:y=566:fontsize=36:fontcolor=0x6F3D21,
drawbox=x=170:y=760:w=230:h=58:color=0xF2DD5C@1:t=fill,
drawtext=fontfile={fp}:text='低成本布景':x=188:y=770:fontsize=34:fontcolor=0x221A10[bg];
[1:v]crop=1500:900:0:150,scale=400:-1,format=rgba,colorkey=0x00FF00:0.28:0.12[boss];
[2:v]crop=1500:900:0:150,scale=520:-1,format=rgba,colorkey=0x00FF00:0.28:0.12[op];
[3:v]crop=1500:900:0:150,scale=390:-1,format=rgba,colorkey=0x00FF00:0.28:0.12[plan];
[bg][boss]overlay=x='160+if(between(t,5,8.5)+between(t,12,15),14*sin(55*t),0)':y='365+10*sin(6.5*t)'[v1];
[v1][op]overlay=x='675+if(between(t,27.8,30)+between(t,41.5,44),26*sin(80*t),0)':y='310+12*sin(7.2*t)'[v2];
[v2][plan]overlay=x='1325+if(between(t,24,27.8)+between(t,38,41.5),16*sin(65*t),0)':y='370+10*sin(6.8*t)'[v3];
[v3]
drawtext=fontfile={fp}:text='老板':x=300:y=355:fontsize=52:fontcolor=0xFFDC23:borderw=7:bordercolor=black,
drawtext=fontfile={fp}:text='我':x=935:y=300:fontsize=56:fontcolor=0xFFDC23:borderw=7:bordercolor=black,
drawtext=fontfile={fp}:text='策划':x=1450:y=360:fontsize=52:fontcolor=0xFFDC23:borderw=7:bordercolor=black,
drawbox=x=515:y=198:w=890:h=92:color=0x181525@0.88:t=fill:enable='between(t,24,27.8)+between(t,38,41.5)',
drawtext=fontfile={fp}:text='腹黑真心话':x=(w-text_w)/2:y=218:fontsize=50:fontcolor=0xFFEB3C:borderw=5:bordercolor=black:enable='between(t,24,27.8)+between(t,38,41.5)',
drawbox=x=500:y=198:w=920:h=92:color=0x1E5F37@0.88:t=fill:enable='between(t,30.9,35.6)+between(t,45,53.5)',
drawtext=fontfile={fp}:text='官方话术模式':x=(w-text_w)/2:y=218:fontsize=50:fontcolor=0xD2FFE1:borderw=5:bordercolor=black:enable='between(t,30.9,35.6)+between(t,45,53.5)',
drawbox=x=0:y=0:w=1920:h=1080:color=red@0.18:t=fill:enable='between(t,16.3,18.4)',
drawtext=fontfile={fp}:text='红温中':x=(w-text_w)/2:y=196:fontsize=94:fontcolor=red:borderw=8:bordercolor=black:enable='between(t,16.3,18.4)',
drawtext=fontfile={fp}:text='啊？？？':x=(w-text_w)/2:y=176:fontsize=112:fontcolor=red:borderw=9:bordercolor=black:enable='between(t,27.8,30)+between(t,41.5,44)',
drawbox=x=0:y=0:w=1920:h=1080:color=black@1:t=fill:enable='between(t,0,5)+between(t,15,16.3)+between(t,30,30.9)+between(t,44,45)+between(t,56,60)',
subtitles={safe_ass}:fontsdir={fonts_dir}[vout]
'''

    def status_payload(self, username: str) -> dict[str, Any]:
        session = self.get_session(username)
        with session.lock:
            return {
                'isWorking': session.is_working,
                'currentAction': session.current_action,
                'lastError': session.last_error,
                'lastStartedAt': session.last_started_at,
                'lastFinishedAt': session.last_finished_at,
            }

    def history_payload(self, username: str) -> list[dict[str, Any]]:
        session = self.get_session(username)
        with session.lock:
            return [asdict(item) for item in session.history]

    def profile_payload(self, username: str) -> dict[str, Any]:
        return {
            'user': username or AGENT_NAME,
            'adapterType': ADAPTER_TYPE,
            'role': '猫meme视频生成师',
            'workspace': str(Path(self.config.workspace).resolve()),
            'identity': '# 猫咪咪\n\n专门负责把文案/主题制作成低成本土味猫 meme 视频的 niuma 员工。',
            'capabilities': ['video', 'ffmpeg', 'subtitles', 'meme', 'bilibili', 'runs', 'artifacts'],
            'supports': {'approvals': False, 'runs': True, 'history': True, 'attachments': False, 'vision': False},
            'tools': [
                {'name': 'ffmpeg', 'label': 'ffmpeg 视频合成', 'requiresApproval': False},
                {'name': 'ass-subtitles', 'label': 'ASS 字幕生成', 'requiresApproval': False},
                {'name': 'green-screen-keying', 'label': '绿幕猫素材抠像', 'requiresApproval': False},
            ],
            'recentMemory': [],
            'budgetMonthly': 0,
            'budgetUsed': 0,
            'reportsTo': '郑十一',
            'health': {'status': 'healthy', 'source': ADAPTER_TYPE, 'message': '猫咪咪待命中'},
        }

    def runs_payload(self, username: str) -> list[dict[str, Any]]:
        session = self.get_session(username)
        with session.lock:
            return [dict(run) for run in session.runs]

    def run_payload(self, username: str, run_id: str) -> dict[str, Any] | None:
        for run in self.runs_payload(username):
            if run.get('runId') == run_id:
                return run
        return None

    def clear(self, username: str) -> dict[str, str]:
        self.get_session(username).clear()
        self._save_state()
        return {'status': 'cleared'}


class CatMimiHandler(BaseHTTPRequestHandler):
    runtime: CatMimiRuntime | None = None
    server_version = 'CatMimiAgent/0.1'

    def do_OPTIONS(self) -> None:
        self.send_response(HTTPStatus.NO_CONTENT)
        self._cors()
        self.end_headers()

    def do_GET(self) -> None:
        parsed = urlparse(self.path)
        username = self._request_user(parsed)
        if parsed.path == '/':
            self._text(HTTPStatus.OK, '猫咪咪 cat meme video agent is running.')
        elif parsed.path == '/api/status':
            self._json(HTTPStatus.OK, self._runtime().status_payload(username))
        elif parsed.path in ('/api/config', '/api/models'):
            self._json(HTTPStatus.OK, {
                'Models': [
                    {
                        'Model': 'CatMeme Video Agent',
                        'Provider': 'catmeme',
                        'EndpointId': 'cat_mimi',
                        'Version': 'local',
                    }
                ]
            })
        elif parsed.path == '/api/history':
            self._json(HTTPStatus.OK, self._runtime().history_payload(username))
        elif parsed.path == '/api/agent/profile':
            self._json(HTTPStatus.OK, self._runtime().profile_payload(username))
        elif parsed.path == '/api/agent/runs':
            self._json(HTTPStatus.OK, self._runtime().runs_payload(username))
        elif parsed.path == '/api/agent/run':
            run = self._runtime().run_payload(username, self._query(parsed, 'id'))
            self._json(HTTPStatus.OK if run else HTTPStatus.NOT_FOUND, run or {'error': 'Run not found'})
        else:
            self._json(HTTPStatus.NOT_FOUND, {'error': 'Not found'})

    def do_POST(self) -> None:
        parsed = urlparse(self.path)
        username = self._username()
        if parsed.path == '/api/chat':
            payload = self._read_json()
            role = unquote(self.headers.get('X-Role', '')).strip()
            result = self._runtime().run_chat(username, role, payload)
            self._text(HTTPStatus.OK, encode_chunk('final', result))
        elif parsed.path == '/api/clear':
            self._json(HTTPStatus.OK, self._runtime().clear(username))
        elif parsed.path == '/api/cancel':
            self._json(HTTPStatus.OK, {'status': 'not-supported', 'message': '当前视频合成任务为同步 ffmpeg 调用，暂不支持中途取消。'})
        elif parsed.path in ('/api/agent/approve', '/api/agent/reject'):
            self._json(HTTPStatus.OK, {'status': 'not-supported'})
        else:
            self._json(HTTPStatus.NOT_FOUND, {'error': 'Not found'})

    def log_message(self, fmt: str, *args: Any) -> None:
        return

    def _runtime(self) -> CatMimiRuntime:
        if self.runtime is None:
            raise RuntimeError('CatMimi runtime not configured')
        return self.runtime

    def _username(self) -> str:
        return unquote(self.headers.get('X-Username', AGENT_NAME)).strip() or AGENT_NAME

    def _request_user(self, parsed: Any) -> str:
        return self._query(parsed, 'user') or self._username()

    @staticmethod
    def _query(parsed: Any, key: str) -> str:
        return unquote(parse_qs(parsed.query).get(key, [''])[0]).strip()

    def _read_json(self) -> dict[str, Any]:
        length = int(self.headers.get('Content-Length', '0') or '0')
        raw = self.rfile.read(length) if length else b'{}'
        return json.loads(raw.decode('utf-8')) if raw else {}

    def _cors(self) -> None:
        self.send_header('Access-Control-Allow-Origin', '*')
        self.send_header('Access-Control-Allow-Headers', 'Content-Type, X-Username, X-Team-Url, X-Role, X-Adapter-Type')
        self.send_header('Access-Control-Allow-Methods', 'GET, POST, OPTIONS')

    def _json(self, status: HTTPStatus, payload: Any) -> None:
        data = json.dumps(payload, ensure_ascii=False).encode('utf-8')
        self.send_response(status)
        self._cors()
        self.send_header('Content-Type', 'application/json; charset=utf-8')
        self.send_header('Content-Length', str(len(data)))
        self.end_headers()
        self.wfile.write(data)

    def _text(self, status: HTTPStatus, text: str) -> None:
        data = text.encode('utf-8')
        self.send_response(status)
        self._cors()
        self.send_header('Content-Type', 'text/plain; charset=utf-8')
        self.send_header('Content-Length', str(len(data)))
        self.end_headers()
        self.wfile.write(data)


def create_server(config: CatMimiConfig) -> ThreadingHTTPServer:
    CatMimiHandler.runtime = CatMimiRuntime(config)
    return ThreadingHTTPServer((config.host, config.port), CatMimiHandler)


def main() -> None:
    parser = argparse.ArgumentParser(description='猫咪咪 niuma cat meme video agent')
    parser.add_argument('--config', default=None)
    args = parser.parse_args()
    config = CatMimiConfig.load(args.config)
    server = create_server(config)
    print(f'[CatMimi] Listening on http://{config.host}:{config.port}/ workspace={Path(config.workspace).resolve()}')
    server.serve_forever()


if __name__ == '__main__':
    main()

#!/usr/bin/env python3
"""
NiumaClaw local Agent Runner.

Usage:
  python agent_runner.py --server http://127.0.0.1:4055 --token nnode_xxx --adapter codex --workspace E:\\work
  python agent_runner.py --server https://your-domain --token nnode_xxx --adapter hermes --command-template "hermes {prompt}"
  python agent_runner.py --server https://your-domain --token nnode_xxx --adapter claude --command-template "claude -p {prompt}"

The runner keeps a private bearer token on the user's own computer, polls the Team
service for jobs assigned to this account/device, runs the local command, and posts
the result back. Use --adapter echo for a safe smoke test.
"""

from __future__ import annotations

import argparse
import json
import os
import platform
import shlex
import socket
import subprocess
import sys
import time
import urllib.error
import urllib.request


VERSION = "0.1.0"


def request_json(server: str, path: str, token: str, payload: dict, timeout: int = 35) -> dict:
    url = server.rstrip("/") + path
    data = json.dumps(payload, ensure_ascii=False).encode("utf-8")
    req = urllib.request.Request(
        url,
        data=data,
        headers={
            "Authorization": f"Bearer {token}",
            "Content-Type": "application/json; charset=utf-8",
            "User-Agent": f"NiumaClaw-AgentRunner/{VERSION}",
        },
        method="POST",
    )
    with urllib.request.urlopen(req, timeout=timeout) as resp:
        raw = resp.read().decode("utf-8")
        return json.loads(raw) if raw else {}


def runner_capabilities(adapter: str, workspace: str) -> dict:
    return {
        "adapter": adapter,
        "workspace": workspace,
        "host": socket.gethostname(),
        "platform": platform.platform(),
        "supports": ["chat", "tasks", "terminal", "files", "code", "runner"],
    }


def quote_prompt(prompt: str) -> str:
    if os.name == "nt":
        return subprocess.list2cmdline([prompt])
    return shlex.quote(prompt)


def default_command(adapter: str, prompt: str) -> str:
    quoted = quote_prompt(prompt)
    if adapter == "hermes":
        return f"hermes {quoted}"
    if adapter == "claude":
        return f"claude -p {quoted}"
    if adapter == "echo":
        return ""
    return f"codex exec {quoted}"


def run_job(adapter: str, prompt: str, workspace: str, command_template: str | None, timeout_seconds: int) -> tuple[bool, str, str | None]:
    if adapter == "echo":
        return True, f"[echo runner]\n{prompt}", None

    template = command_template or os.environ.get("NIUMACLAW_RUNNER_COMMAND_TEMPLATE") or default_command(adapter, prompt)
    if "{prompt}" in template:
        command = template.replace("{prompt}", quote_prompt(prompt))
    else:
        command = template

    if not command.strip():
        return False, "", "No command configured for this adapter."

    try:
        completed = subprocess.run(
            command,
            cwd=workspace or None,
            shell=True,
            text=True,
            encoding="utf-8",
            errors="replace",
            capture_output=True,
            timeout=timeout_seconds,
        )
    except subprocess.TimeoutExpired as exc:
        output = (exc.stdout or "") + ("\n" + exc.stderr if exc.stderr else "")
        return False, output.strip(), f"Command timed out after {timeout_seconds}s."
    except Exception as exc:  # noqa: BLE001 - this is a boundary process runner
        return False, "", str(exc)

    output = "\n".join(part for part in [completed.stdout.strip(), completed.stderr.strip()] if part)
    if completed.returncode == 0:
        return True, output or "Command completed without output.", None
    return False, output, f"Command exited with code {completed.returncode}."


def main() -> int:
    parser = argparse.ArgumentParser(description="NiumaClaw local Agent Runner")
    parser.add_argument("--server", required=True, help="Team service URL, for example https://example.com or http://127.0.0.1:4055")
    parser.add_argument("--token", required=True, help="Agent node token from NiumaClaw")
    parser.add_argument("--adapter", default="codex", choices=["codex", "hermes", "claude", "echo"], help="Local agent command type")
    parser.add_argument("--workspace", default=os.getcwd(), help="Working directory for the local command")
    parser.add_argument("--command-template", default=None, help='Optional shell template, for example: "codex exec {prompt}"')
    parser.add_argument("--poll-timeout-ms", type=int, default=25000)
    parser.add_argument("--job-timeout-seconds", type=int, default=1800)
    parser.add_argument("--once", action="store_true", help="Poll once and exit")
    args = parser.parse_args()

    workspace = os.path.abspath(args.workspace)
    capabilities = runner_capabilities(args.adapter, workspace)
    print(f"NiumaClaw Agent Runner {VERSION} | {args.adapter} | {workspace}", flush=True)

    while True:
        try:
            request_json(
                args.server,
                "/api/agent-nodes/heartbeat",
                args.token,
                {
                    "platform": platform.platform(),
                    "version": VERSION,
                    "capabilities": capabilities,
                },
                timeout=15,
            )
            polled = request_json(
                args.server,
                "/api/agent-nodes/jobs/poll",
                args.token,
                {
                    "timeoutMs": args.poll_timeout_ms,
                    "capabilities": capabilities,
                },
                timeout=max(10, int(args.poll_timeout_ms / 1000) + 10),
            )
            job = polled.get("job")
            if not job:
                if args.once:
                    return 0
                continue

            job_id = job["id"]
            employee = job.get("employeeName") or "agent"
            prompt = job.get("prompt") or ""
            print(f"[job {job_id}] {employee}: {prompt[:80]}", flush=True)
            request_json(args.server, f"/api/agent-nodes/jobs/{job_id}/start", args.token, {"message": "started"}, timeout=15)
            ok, output, error = run_job(args.adapter, prompt, workspace, args.command_template, args.job_timeout_seconds)
            request_json(
                args.server,
                f"/api/agent-nodes/jobs/{job_id}/finish",
                args.token,
                {
                    "ok": ok,
                    "output": output,
                    "error": error,
                    "metadata": {
                        "adapter": args.adapter,
                        "workspace": workspace,
                        "commandTemplate": args.command_template or os.environ.get("NIUMACLAW_RUNNER_COMMAND_TEMPLATE") or "",
                    },
                },
                timeout=30,
            )
            print(f"[job {job_id}] {'done' if ok else 'failed'}", flush=True)
            if args.once:
                return 0
        except urllib.error.HTTPError as exc:
            body = exc.read().decode("utf-8", errors="replace")
            print(f"HTTP {exc.code}: {body}", file=sys.stderr, flush=True)
            if args.once:
                return 2
            time.sleep(5)
        except KeyboardInterrupt:
            print("Stopped.", flush=True)
            return 0
        except Exception as exc:  # noqa: BLE001 - keep runner alive
            print(f"Runner error: {exc}", file=sys.stderr, flush=True)
            if args.once:
                return 2
            time.sleep(5)


if __name__ == "__main__":
    raise SystemExit(main())

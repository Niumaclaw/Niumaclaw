#!/usr/bin/env bash
set -euo pipefail

ROOT_DIR="$(cd "$(dirname "$0")/../.." && pwd)"
OUTPUT_DIR="$ROOT_DIR/downloads"
OUTPUT_DMG="$OUTPUT_DIR/NiumaClaw-macOS-Agent-template.dmg"
WORK_DIR="$(mktemp -d)"

cleanup() {
  rm -rf "$WORK_DIR"
}
trap cleanup EXIT

APP_DIR="$WORK_DIR/src/NiumaClaw Agent.app"
mkdir -p "$APP_DIR/Contents/MacOS" "$APP_DIR/Contents/Resources" "$OUTPUT_DIR"

cat > "$APP_DIR/Contents/Info.plist" <<'PLIST'
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
  <key>CFBundleDevelopmentRegion</key>
  <string>en</string>
  <key>CFBundleExecutable</key>
  <string>NiumaClaw Agent</string>
  <key>CFBundleIdentifier</key>
  <string>wiki.niuma.agent</string>
  <key>CFBundleName</key>
  <string>NiumaClaw Agent</string>
  <key>CFBundleDisplayName</key>
  <string>NiumaClaw Agent</string>
  <key>CFBundlePackageType</key>
  <string>APPL</string>
  <key>CFBundleShortVersionString</key>
  <string>1.0.0</string>
  <key>CFBundleVersion</key>
  <string>1</string>
  <key>LSMinimumSystemVersion</key>
  <string>10.13</string>
</dict>
</plist>
PLIST

python3 - "$APP_DIR/Contents/MacOS/NiumaClaw Agent" <<'PY'
from pathlib import Path
import sys

capacity = 65536
script = """#!/bin/bash
set -euo pipefail

CONFIG_B64="__NIUMACLAW_CONFIG_B64_START__""" + ("#" * capacity) + """__NIUMACLAW_CONFIG_B64_END__"
CONFIG_B64="${CONFIG_B64#__NIUMACLAW_CONFIG_B64_START__}"
CONFIG_B64="${CONFIG_B64%__NIUMACLAW_CONFIG_B64_END__}"
CONFIG_B64="${CONFIG_B64%%#*}"

if ! command -v python3 >/dev/null 2>&1; then
  /usr/bin/osascript -e 'display dialog "Python 3 is required to run NiumaClaw Agent." buttons {"OK"} default button "OK" with title "NiumaClaw Agent"' >/dev/null 2>&1 || true
  exit 1
fi

exec python3 - "$CONFIG_B64" <<'PYAPP'
import base64
import json
import os
import pathlib
import shlex
import subprocess
import sys
import traceback
import urllib.request

TITLE = "NiumaClaw Agent"

def osa_quote(value):
    return json.dumps(str(value))[1:-1]

def notify(message):
    script = 'display notification "' + osa_quote(message) + '" with title "' + TITLE + '"'
    subprocess.run(["/usr/bin/osascript", "-e", script], stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL, check=False)

def dialog(message):
    script = 'display dialog "' + osa_quote(message) + '" buttons {"OK"} default button "OK" with title "' + TITLE + '"'
    subprocess.run(["/usr/bin/osascript", "-e", script], stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL, check=False)

def main():
    if len(sys.argv) < 2 or not sys.argv[1]:
        raise RuntimeError("This DMG does not contain a client configuration.")
    cfg = json.loads(base64.b64decode(sys.argv[1]).decode("utf-8"))
    home = pathlib.Path.home()
    install_dir = home / "Library" / "Application Support" / "NiumaClawAgent"
    log_dir = home / "Library" / "Logs" / "NiumaClawAgent"
    install_dir.mkdir(parents=True, exist_ok=True)
    log_dir.mkdir(parents=True, exist_ok=True)

    workspace = os.environ.get("NIUMACLAW_WORKSPACE") or cfg.get("workspace") or str(home / "NiumaClawWorkspace")
    workspace = os.path.expandvars(os.path.expanduser(workspace))
    pathlib.Path(workspace).mkdir(parents=True, exist_ok=True)

    runner_path = install_dir / "agent_runner.py"
    runner_b64 = cfg.get("runner") or ""
    if runner_b64:
        runner_path.write_bytes(base64.b64decode(runner_b64))
    else:
        urllib.request.urlretrieve(cfg["server"].rstrip("/") + "/agent_runner.py", runner_path)
    os.chmod(runner_path, 0o600)

    client_json = {
        "server": cfg["server"],
        "nodeId": cfg["nodeId"],
        "adapter": cfg["adapter"],
        "adapterType": cfg["adapterType"],
        "deviceName": cfg["deviceName"],
    }
    client_path = install_dir / "client.json"
    client_path.write_text(json.dumps(client_json, ensure_ascii=False, indent=2) + "\\n", encoding="utf-8")
    os.chmod(client_path, 0o600)

    launcher_path = install_dir / "start-niumaclaw-agent.command"
    command = [
        "python3",
        str(runner_path),
        "--server",
        cfg["server"],
        "--token",
        cfg["token"],
        "--adapter",
        cfg["adapter"],
        "--workspace",
        workspace,
    ]
    launcher_path.write_text(
        "#!/bin/bash\\n"
        "set -euo pipefail\\n"
        "cd " + shlex.quote(workspace) + "\\n"
        "echo 'NiumaClaw macOS Agent'\\n"
        "echo 'Node ID: " + str(cfg["nodeId"]).replace("'", "'\\\\''") + "'\\n"
        "echo 'Workspace: " + workspace.replace("'", "'\\\\''") + "'\\n"
        "echo\\n"
        "exec " + " ".join(shlex.quote(part) for part in command) + "\\n",
        encoding="utf-8",
    )
    os.chmod(launcher_path, 0o700)

    notify("Agent is starting in Terminal.")
    try:
        subprocess.Popen(["/usr/bin/open", "-a", "Terminal", str(launcher_path)])
    except Exception:
        log_file = open(log_dir / "agent.log", "ab", buffering=0)
        subprocess.Popen(command, stdout=log_file, stderr=subprocess.STDOUT, cwd=workspace)
        notify("Agent started in the background. Logs are in Library/Logs/NiumaClawAgent.")

if __name__ == "__main__":
    try:
        main()
    except Exception as exc:
        error_log = pathlib.Path.home() / "Library" / "Logs" / "NiumaClawAgent" / "launch-error.log"
        error_log.parent.mkdir(parents=True, exist_ok=True)
        error_log.write_text(traceback.format_exc(), encoding="utf-8")
        dialog("Failed to start NiumaClaw Agent: " + str(exc))
        raise
PYAPP
"""

path = Path(sys.argv[1])
path.write_text(script, encoding="utf-8")
path.chmod(0o755)
PY

hdiutil create \
  -volname "NiumaClaw Agent" \
  -srcfolder "$WORK_DIR/src" \
  -ov \
  -fs HFS+ \
  -format UDRW \
  "$OUTPUT_DMG"

echo "$OUTPUT_DMG"

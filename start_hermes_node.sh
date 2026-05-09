#!/usr/bin/env bash
set -euo pipefail

PROJECT_DIR="${NIUMA_PROJECT_DIR:-/mnt/e/新建文件夹/文件/niuma}"
cd "$PROJECT_DIR"
mkdir -p logs

if curl --noproxy '*' -fsS http://127.0.0.1:5061/api/config >/dev/null 2>&1; then
  echo "Hermes worker already running: http://127.0.0.1:5061"
else
  export HERMES_NODE_CONFIG="$PROJECT_DIR/hermes_node_config_win.json"
  nohup python3 hermes_adapter.py > logs/hermes_5061.out.log 2> logs/hermes_5061.err.log &
  echo "Hermes worker starting: http://127.0.0.1:5061"
fi

if curl --noproxy '*' -fsS http://127.0.0.1:5077/api/config >/dev/null 2>&1; then
  echo "Cat Mimi worker already running: http://127.0.0.1:5077"
else
  nohup python3 agents/cat_mimi/cat_mimi_agent.py --config agents/cat_mimi/cat_mimi_config.json > logs/cat_mimi_5077.out.log 2> logs/cat_mimi_5077.err.log &
  echo "Cat Mimi worker starting: http://127.0.0.1:5077"
fi

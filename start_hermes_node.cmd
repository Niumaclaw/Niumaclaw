@echo off
setlocal
set "PROJECT=%~dp0"
set "LOGDIR=%PROJECT%logs"
if not exist "%LOGDIR%" mkdir "%LOGDIR%"

powershell.exe -NoProfile -ExecutionPolicy Bypass -Command "try { $r = Invoke-WebRequest -Uri 'http://127.0.0.1:5061/api/config' -UseBasicParsing -TimeoutSec 3; if ($r.StatusCode -ge 200 -and $r.StatusCode -lt 300) { exit 0 } } catch {}; exit 1"
if errorlevel 1 (
  start "Hermes 5061" /min powershell.exe -NoProfile -Command "$env:HERMES_NODE_CONFIG='%PROJECT%hermes_node_config_win.json'; Set-Location '%PROJECT%'; py -3.14 hermes_adapter.py 1> '%LOGDIR%\hermes_5061.out.log' 2> '%LOGDIR%\hermes_5061.err.log'"
  echo Hermes worker starting: http://127.0.0.1:5061
) else (
  echo Hermes worker already running: http://127.0.0.1:5061
)

powershell.exe -NoProfile -ExecutionPolicy Bypass -Command "try { $r = Invoke-WebRequest -Uri 'http://127.0.0.1:5077/api/config' -UseBasicParsing -TimeoutSec 3; if ($r.StatusCode -ge 200 -and $r.StatusCode -lt 300) { exit 0 } } catch {}; exit 1"
if errorlevel 1 (
  for /f "usebackq delims=" %%i in (`wsl.exe -d Ubuntu -- wslpath -a "%PROJECT%"`) do set "WSL_PROJECT=%%i"
  start "Cat Mimi 5077" /min wsl.exe -d Ubuntu -- bash -lc "cd '%WSL_PROJECT%' && exec python3 agents/cat_mimi/cat_mimi_agent.py --config agents/cat_mimi/cat_mimi_config.json"
  echo Cat Mimi worker starting: http://127.0.0.1:5077
) else (
  echo Cat Mimi worker already running: http://127.0.0.1:5077
)

endlocal

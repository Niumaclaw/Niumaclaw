@echo off
chcp 65001 >nul
setlocal

cd /d "%~dp0"

powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0start_team_lan.ps1"

pause

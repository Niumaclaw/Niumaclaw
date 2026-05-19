$ErrorActionPreference = "Stop"

$Repo = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $Repo

$Port = 4050
$Prefix = "http://+:$Port/"
$RuleName = "NiumaClaw Team $Port"

$principal = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())
$isAdmin = $principal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)

if (-not $isAdmin) {
    Write-Host "[NiumaClaw] LAN mode needs Administrator permission for URL ACL and firewall setup."
    Start-Process -FilePath "powershell.exe" -ArgumentList @(
        "-NoProfile",
        "-ExecutionPolicy", "Bypass",
        "-File", "`"$PSCommandPath`""
    ) -Verb RunAs
    exit
}

function Stop-NiumaClawTeamProcesses {
    Write-Host "[NiumaClaw] Stopping old Team processes..."
    $processes = Get-CimInstance Win32_Process |
        Where-Object {
            $_.Name -eq "NiumaClaw.Team.exe" -or
            ($_.Name -eq "dotnet.exe" -and $_.CommandLine -match "NiumaClaw\.Team")
        }

    foreach ($process in $processes) {
        if ($process.ProcessId -eq $PID) { continue }
        Write-Host "  stop pid=$($process.ProcessId) $($process.Name)"
        Stop-Process -Id $process.ProcessId -Force -ErrorAction SilentlyContinue
    }

    Start-Sleep -Seconds 2
}

Stop-NiumaClawTeamProcesses

Write-Host "[NiumaClaw] Configuring URL ACL: $Prefix"
$urlAcl = netsh http show urlacl url=$Prefix 2>$null
if (-not $urlAcl) {
    netsh http add urlacl url=$Prefix sddl="D:(A;;GX;;;WD)" | Out-Host
}

Write-Host "[NiumaClaw] Configuring Windows Firewall inbound rule: $RuleName"
$existingRule = Get-NetFirewallRule -DisplayName $RuleName -ErrorAction SilentlyContinue
if (-not $existingRule) {
    New-NetFirewallRule -DisplayName $RuleName -Direction Inbound -Action Allow -Protocol TCP -LocalPort $Port | Out-Null
}

$env:NiumaClaw_TEAM_URLS = $Prefix

Write-Host ""
Write-Host "[NiumaClaw] LAN access URLs:"
Get-NetIPAddress -AddressFamily IPv4 |
    Where-Object { $_.IPAddress -notlike "127.*" -and $_.PrefixOrigin -ne "WellKnown" } |
    ForEach-Object { Write-Host "  http://$($_.IPAddress):$Port/" }

Write-Host ""
Write-Host "[NiumaClaw] Building Team service..."
dotnet build
if ($LASTEXITCODE -ne 0) {
    throw "dotnet build failed. Please close any old NiumaClaw.Team window and run this script again."
}

Write-Host ""
Write-Host "[NiumaClaw] Starting Team service in LAN mode..."
dotnet run --no-build

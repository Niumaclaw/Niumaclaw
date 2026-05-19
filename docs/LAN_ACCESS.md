# NiumaClaw Team 局域网访问说明

默认的 `http://localhost:4050/` 只能在本机访问。要让同一 Wi-Fi / 同一局域网里的同事访问，需要使用局域网启动模式。

## 一键启动

推荐在项目目录中右键以管理员身份运行：

```powershell
start_team_lan.ps1
```

如果双击/右键运行 PowerShell 脚本受限，也可以运行：

```bat
start_team_lan.cmd
```

脚本会自动完成三件事：

1. 配置 Windows URL ACL：允许 `http://+:4050/` 监听。
2. 配置 Windows 防火墙入站规则：允许同网络访问 TCP `4050`。
3. 以局域网模式启动 Team 服务。

启动后，同事访问：

```text
http://你的电脑局域网IP:4050/
```

例如当前电脑的局域网地址可能是：

```text
http://192.168.0.54:4050/
```

## 查看自己的局域网 IP

可以在 PowerShell 里运行：

```powershell
Get-NetIPAddress -AddressFamily IPv4 |
  Where-Object { $_.IPAddress -notlike '127.*' -and $_.PrefixOrigin -ne 'WellKnown' } |
  Select-Object InterfaceAlias, IPAddress
```

## 注意事项

- 同事必须和你的电脑处在同一个网络下。
- 如果你的网络是“公用网络”，Windows 防火墙可能仍会拦截，建议切到“专用网络”。
- 不要把这个地址暴露到公网；当前模式适合同办公室、同 Wi-Fi 或内网测试。
- 员工节点地址仍可以保持 `http://127.0.0.1:5050`，因为 Team 服务会在主机本机代理请求。

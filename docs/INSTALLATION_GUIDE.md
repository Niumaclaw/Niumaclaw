# NiumaClaw 桌面端安装教程

本文面向试用用户，说明如何在 Windows 和 macOS 上安装 NiumaClaw Agent，并连接到 `https://niuma.wiki`。

## 安装前准备

- 已登录 `https://niuma.wiki`。
- 本机可以访问互联网。
- 已安装至少一个可执行工具：Codex CLI、Hermes 或 Claude Code。
- 建议准备一个专用工作区，例如：
  - macOS：`~/NiumaClawWorkspace`
  - Windows：`C:\Users\<你的用户名>\NiumaClawWorkspace`

## Windows 安装

1. 在网页首页点击“下载客户端”。
2. 点击“下载 Windows 桌面端”。
3. 浏览器下载 `NiumaClaw-...-Windows-Agent.exe` 后双击打开。
4. 首次打开会自动安装到当前用户目录，并创建桌面和开始菜单快捷方式。
5. 安装完成后会自动启动 `NiumaClaw Agent`。
6. 保持客户端窗口打开，回到网页端点击“查看在线客户端”。
7. 看到“已发现在线客户端”后，即可绑定员工并派发任务。

如果 Windows 阻止运行，选择“更多信息”，确认来源后点击“仍要运行”。正式商业发布建议接入代码签名证书。

## macOS 安装

1. 在网页首页点击“下载客户端”。
2. 点击“下载 macOS DMG”。
3. 打开下载的 `.dmg` 文件。
4. 将 `NiumaClaw Agent.app` 拖入 Applications，或直接双击启动客户端。
5. 如果 macOS 提示无法验证开发者，先点“完成”，然后在 Finder 中右键 `NiumaClaw Agent.app`，选择“打开”。
6. 客户端打开后，保持窗口运行，回到网页端点击“查看在线客户端”。
7. 看到“已发现在线客户端”后，即可绑定员工并派发任务。

正式商业发布应完成 Developer ID 签名和 notarization，避免用户看到 Gatekeeper 拦截。

## 工作区建议

桌面 Agent 会在配置的工作区内运行 Codex、Hermes 或 Claude Code。建议使用单独目录，避免误操作个人文件：

```text
~/NiumaClawWorkspace
```

如果工作区不存在，客户端诊断会提示创建或修改路径。

## 验证安装成功

安装成功后应满足：

- 桌面端显示“已连接，待命中”。
- 网页下载弹窗显示“已发现在线客户端”。
- 智能体面板能看到客户端节点号和最后心跳。
- 向员工派发一条简单任务后，桌面端会显示任务内容，网页工作日志能看到最终回复。

## 卸载或换机

- Windows：从开始菜单或系统设置中移除快捷方式和安装目录。
- macOS：删除 `NiumaClaw Agent.app`。
- 网页端：打开员工工作日志的智能体面板，点击“解绑节点”。解绑后旧客户端 token 会立即失效，不能继续领任务。

# Codex CLI 安装与登录说明

NiumaClaw 的 Codex 桌面客户端会调用本机 `codex` 命令执行任务。因此，桌面端连接成功只是第一步，还需要确保本机终端能直接运行 Codex CLI。

## 1. 检查是否已安装

在终端运行：

```bash
codex --version
```

如果能输出版本号，说明命令已安装。然后运行：

```bash
which codex
```

记下输出路径。桌面端会自动补齐常见路径，如果仍检测失败，可重启客户端。

## 2. 安装 Codex CLI

请优先参考 OpenAI 官方文档或你当前 Codex 产品界面的安装说明。安装完成后重新打开一个终端，再运行：

```bash
codex --version
```

如果提示 `command not found`，说明命令还没有进入 PATH。

## 3. 登录 Codex

在终端运行 Codex 登录命令，并按提示完成浏览器授权或 token 配置。登录后可以先做一次本地测试：

```bash
codex exec --skip-git-repo-check --cd ~/NiumaClawWorkspace "你好，请用一句话回复当前目录是否可用"
```

如果命令能返回文本，说明 NiumaClaw 桌面 Agent 也可以调用 Codex。

## 4. macOS 双击 App 找不到 codex

macOS 图形应用和终端的 PATH 可能不同。NiumaClaw Agent 已内置常见路径补齐，包括：

- `/opt/homebrew/bin`
- `/usr/local/bin`
- `~/.local/bin`
- `~/.npm-global/bin`

如果仍失败：

1. 在终端运行 `which codex`。
2. 确认路径是否在上面的常见目录内。
3. 如果不在，请把 Codex 安装到常见目录，或创建软链接。
4. 关闭并重新打开 `NiumaClaw Agent.app`。

## 5. Windows 找不到 codex

在 PowerShell 运行：

```powershell
codex --version
where.exe codex
```

如果 PowerShell 能找到，但桌面端找不到：

1. 关闭 NiumaClaw Agent。
2. 确认 Codex 安装目录已加入用户 PATH。
3. 重新打开 NiumaClaw Agent。
4. 回到网页端重新派发测试任务。

## 6. 推荐自检任务

连接完成后，在网页端给 Codex 员工派发：

```text
你好，请确认你已经连接到本机 Codex，并说明当前工作区路径。
```

工作日志能看到清楚回复，就说明 Codex CLI、桌面端和网页端闭环可用。

# Release Notes

## v1.0.5 - Public Download URL Fix

### Highlights

- 桌面客户端下载配置优先使用反向代理传入的 `X-Forwarded-Proto` 和 `X-Forwarded-Host`，公网 HTTPS 下载的 macOS DMG 会写入 `https://niuma.wiki`。
- 同步修正 Windows 安装包和跨平台 zip 内的服务地址，避免反代后写成内部 HTTP 地址。

## v1.0.4 - Native macOS DMG Client

### Highlights

- macOS 下载入口改为直接下载 `.dmg` 安装镜像，不再下载 `.command` 启动脚本。
- DMG 内含 `NiumaClaw Agent.app`，双击后会安装账号专属 runner/config 并打开 Terminal 启动本机 Agent。
- 后端使用预生成的 macOS DMG 模板，在下载时写入当前账号 token、节点 ID、adapter、workspace 和 runner，线上 Linux 服务器无需动态生成镜像。
- 前端弹窗、下载文件名和成功提示统一改为 macOS DMG。

## v1.0.3 - Direct macOS Desktop Client

### Highlights

- macOS 下载入口改为直接下载单个 `.command` 客户端文件，不再下载 zip。
- macOS 客户端首次运行会把内置 `agent_runner.py` 和 `client.json` 安装到用户目录，然后直接启动本机 Agent。
- 招聘员工流程在 macOS 浏览器中默认生成直接客户端文件；Windows 继续下载安装包，Linux 继续使用 zip 兼容包。

## v1.0.2 - macOS Desktop Client

### Highlights

- 下载客户端弹窗新增“下载 macOS 客户端”入口，不再只展示 Windows 安装包。
- macOS 客户端下载账号专属 zip，内含 `start-niumaclaw-agent.command`、`start-niumaclaw-agent.sh`、`agent_runner.py` 和 `client.json`。
- zip 内 macOS/Linux 启动脚本写入可执行权限，解压后可直接双击 `.command` 或在终端运行。
- 在招聘员工流程中，macOS/Linux 浏览器会默认下载跨平台客户端包，Windows 继续下载安装包。

## v1.0.1 - Online Server Sync

这个版本把 `niuma.wiki` 当前线上发布包作为最新版本同步回 GitHub 和本地源码。

### Highlights

- 同步服务器发布目录 `/opt/niumaclaw/releases/20260608115731` 的前端页面，`index.html` 与线上文件字节级一致。
- 将线上 Team 服务 DLL 中的未推送后端能力恢复为源码，包括账号登录/注册、账户配置、Agent Node 注册/轮询/下载、看板审批状态等接口。
- 加入线上使用的 `agent_runner.py`，保证桌面 Agent 节点下载入口可随源码构建输出。
- 修正版本号为 `1.0.1+online.20260608115731`，不再把旧 GitHub 提交 `3d0b773` 标记为最新版。
- 记录服务器发布包关键文件哈希，方便后续确认源码同步来源。

## v0.1.0 - First Public Preview

NiumaClaw v0.1.0 是第一个面向 GitHub 展示和试用的公开预览版本，重点是把项目包装完整，并让使用者快速理解它解决的问题。

### Highlights

- 多 Agent 可视化中控台：用办公桌和成员卡片管理多个 Agent 节点。
- 任务派发：向指定 Agent 发送任务，并查看执行过程。
- 流式工作日志：展示运行阶段、产物、最终结果和可继续迭代的上下文。
- 项目看板：跟踪战略任务、负责人、状态和运行绑定。
- 周期任务：管理重复执行的任务和执行历史。
- SOP 与治理：维护团队制度，并为高风险操作预留审批入口。
- GitHub 包装：README 头图、Demo 视频、截图、Roadmap、Issue 模板和 MIT License。

### Quick Start

```powershell
git clone https://github.com/Niumaclaw/Niumaclaw.git
cd Niumaclaw
dotnet run
```

Then open:

```text
http://localhost:4050/
```

### Known Limits

- 当前版本更适合本地试用和开发验证。
- GitHub Release 二进制包需要后续 CI 构建或手动上传。
- 不同 Agent 节点的协议和能力仍在继续抽象。

### Suggested GitHub Release Body

```markdown
# NiumaClaw v0.1.0

第一个公开预览版本：一个面向一人公司和小团队的多 Agent 协同工作中控台。

## 功能亮点

- 可视化团队中控台
- 多 Agent 成员管理和任务派发
- 流式执行日志与运行详情
- 项目看板和战略任务拆解
- 周期任务与 SOP 管理
- 审批治理、告警心跳和本地产物追踪

## 快速启动

```powershell
git clone https://github.com/Niumaclaw/Niumaclaw.git
cd Niumaclaw
dotnet run
```

打开 `http://localhost:4050/`。
```

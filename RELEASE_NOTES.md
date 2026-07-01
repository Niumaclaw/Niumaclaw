# Release Notes

## v1.0.16 - Agent Running State UI

### Highlights

- macOS/Windows 桌面 Agent 自动启动后，按钮从“启动 Agent”改为“Agent 已运行”，避免灰色启动按钮被误解为无法启动。
- Agent 在线等待任务时状态改为“已连接，待命中”，并在日志里明确提示正在等待网页派发任务。

## v1.0.15 - Native Desktop App Repair

### Highlights

- 修复 macOS 账号专属 DMG 把配置写入已签名 `.app` 导致 “NiumaClaw Agent 已损坏，无法打开” 的问题。
- macOS DMG 改为标准安装盘结构，包含真实 `NiumaClaw Agent.app`、`Applications` 快捷方式、首次打开说明和应用图标。
- 桌面端会从 DMG 根目录或已挂载的 NiumaClaw 卷读取账号配置，并自动保存到用户配置目录，后续可作为真正桌面应用持续运行。

## v1.0.14 - Stable Browser Home Download

### Highlights

- 首页改由 nginx 单层 gzip，避免应用和反代压缩/缓冲策略不一致导致刷新白屏或按钮脚本未就绪。
- 线上反代配合关闭代理缓冲，让首页与大文件下载更稳定地流式返回。

## v1.0.13 - Download Header Stability

### Highlights

- 大文件下载路由支持 HEAD 快速返回响应头，避免浏览器预检或公网验证卡在附件流上。
- macOS DMG、Windows EXE 与旧安装器下载仍使用 GET 正常传输文件。

## v1.0.12 - Native Windows Download Route

### Highlights

- 补齐 Windows 原生桌面端 `.exe` 静态下载路由，公网直接访问模板文件不再返回 404。
- 继续保留账号专属动态下载，网页登录后下载到的 Windows 客户端会自动携带当前账号节点配置。

## v1.0.11 - Smaller Home Page Gzip

### Highlights

- 首页内置 gzip 改用更小体积的压缩级别，减少公网刷新等待。
- 延续 v1.0.10 的登录遮罩点击拦截修复和原生桌面端下载入口。

## v1.0.10 - Native Desktop Download Fix

### Highlights

- 修复账号登录遮罩在刷新/接口 401 后残留拦截点击的问题，下载客户端按钮不再出现“点了没反应”。
- 首页响应增加 gzip 支持，降低刷新后加载和脚本生效等待时间。
- 下载弹窗会复用服务端注入的已登录账号信息，避免账号同步中误判为未登录。

## v1.0.9 - Native Desktop Clients

### Highlights

- 新增 `NiumaClaw.Agent` 原生桌面客户端，macOS/Windows 都使用带窗口的可执行程序运行本机 Agent。
- macOS DMG 模板改为真实 `NiumaClaw Agent.app`，服务端下载时注入当前账号节点配置。
- Windows 下载改为账号专属 `NiumaClaw-Agent-Windows.exe`，不再依赖脚本安装器追加配置。

## v1.0.8 - macOS Direct Download Fix

### Highlights

- macOS 客户端下载改为浏览器直连 `/api/agent-nodes/macos-client`，避免异步 blob 下载在页面压力大时看起来没有反应。
- macOS 下载接口支持 GET 直链，同时保留 POST 生成逻辑。
- 补齐 `/downloads/NiumaClaw-macOS-Agent-template.dmg` 静态路由，线上 DMG 文件不再返回 404。

## v1.0.7 - Desktop Download Responsiveness Fix

### Highlights

- 首页员工状态轮询增加防重入，上一轮未完成时不会继续叠加新请求。
- 任务徽标刷新从每 2 秒每员工一次降到 30 秒一次，减少刷新后浏览器主线程和网络压力。
- 解决员工较多时刷新页面后“下载客户端”等按钮点击无响应的问题。

## v1.0.6 - macOS Gatekeeper First Launch Help

### Highlights

- macOS DMG 内新增“首次打开说明”，提示使用 Control/右键打开未公证客户端。
- 页面下载提示同步说明 macOS Gatekeeper 行为，避免用户普通双击后被系统拦截却不知道下一步。
- 调整 macOS DMG 模板结构，将动态下载配置放在 app 外部，给后续 Developer ID 签名与 notarization 留出空间。

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

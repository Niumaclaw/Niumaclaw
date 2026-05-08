# Release Notes

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

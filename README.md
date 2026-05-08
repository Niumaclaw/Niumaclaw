# NiumaClaw

<p align="center">
  <strong>一个可视化的多 AI Agent 协同工作中控系统。</strong>
</p>

<p align="center">
  <img alt=".NET" src="https://img.shields.io/badge/.NET-10.0-512BD4">
  <img alt="AOT" src="https://img.shields.io/badge/AOT-Native-7C3AED">
  <img alt="Platform" src="https://img.shields.io/badge/Platform-Windows-0078D4">
  <img alt="License" src="https://img.shields.io/badge/License-MIT-green">
  <img alt="Status" src="https://img.shields.io/badge/Status-Active-brightgreen">
</p>

<p align="center">
  中文 | <a href="#english">English</a>
</p>

---

## 概述

NiumaClaw 是一个基于 .NET 10 的轻量级本地中控台，用可视化“办公室”界面管理多个 AI Agent 节点。你可以招募成员、配置节点地址、派发任务、查看执行状态和工作报告，让多 Agent 协作从命令行流程变成更直观的操作台。

| 模块 | 描述 |
| --- | --- |
| `Program.cs` | HTTP 服务、API 路由和主程序入口。 |
| `index.html` | 内置前端页面，提供可视化办公桌、任务派发、报告查看等交互。 |
| `assets/` | 头像、办公场景和界面重设计资源。 |
| `*.png` | 内嵌到程序中的桌面、盆栽和角色图片素材。 |
| `NiumaClaw.Team.csproj` | .NET 项目配置，支持 Native AOT 发布。 |
| `team_config.json` | 本地运行时配置文件，记录 Agent 节点地址与角色信息。 |

> `team_config.json` 通常包含本地节点配置，默认不提交到仓库。首次运行后可在界面中维护。

---

## 功能

| 功能 | 说明 |
| --- | --- |
| 可视化办公桌 | 以桌面和头像展示每个 AI Agent 的状态。 |
| 成员管理 | 支持新增、修改、移除 Agent 节点。 |
| 任务派发 | 选择指定成员并发送任务请求。 |
| 流式响应 | 支持任务执行过程中的实时输出与状态更新。 |
| 报告查看 | 保存并展示 Agent 的最新工作结果。 |
| 记忆清理 | 可清空单个成员或全部成员的上下文。 |
| 本地代理 | 中控服务将请求转发给配置好的 Agent 节点。 |

---

## 安装

```powershell
git clone https://github.com/hu18764568659-lang/Niumaclaw.git
cd Niumaclaw
dotnet run
```

启动后打开：

```text
http://localhost:4050/
```

发布 Native AOT 版本：

```powershell
dotnet publish -c Release -r win-x64
```

---

## 配置

运行时会读取并维护 `team_config.json`。示例结构如下：

```json
{
  "PeerNodes": {
    "张三": {
      "url": "http://localhost:5050",
      "role": "前端工程师"
    },
    "李四": {
      "url": "http://localhost:5051",
      "role": "后端工程师"
    }
  }
}
```

| 字段 | 说明 |
| --- | --- |
| `PeerNodes` | Agent 节点字典，键名为成员名称。 |
| `url` | 节点服务地址。 |
| `role` | 节点角色或岗位说明。 |

---

## API

| 路径 | 方法 | 描述 |
| --- | --- | --- |
| `/` | `GET` | 返回主界面。 |
| `/api/config` | `GET` | 获取成员与节点配置。 |
| `/api/config` | `POST` | 更新成员与节点配置。 |
| `/api/chat` | `POST` | 派发任务并返回流式响应。 |
| `/api/status` | `GET` | 查询成员任务状态。 |
| `/api/history` | `GET` | 获取成员历史记录或报告。 |
| `/api/clear` | `POST` | 清空指定成员记忆。 |
| `/api/clearall` | `POST` | 清空全部成员记忆。 |

---

## 项目结构

```text
NiumaClaw/
├── Program.cs
├── index.html
├── NiumaClaw.Team.csproj
├── Properties/
│   └── launchSettings.json
├── assets/
│   ├── avatars/
│   ├── redesign/
│   └── scenes/
├── img_shrimp_working.png
├── img_empty_desk.png
└── README.md
```

---

## 许可

本项目采用 MIT License。

---

<h2 id="english">English</h2>

NiumaClaw is a lightweight .NET 10 control panel for coordinating multiple AI Agent nodes through a local visual workspace. It provides agent management, task dispatch, streaming responses, status tracking, report viewing, and local proxy routing.

```powershell
git clone https://github.com/hu18764568659-lang/Niumaclaw.git
cd Niumaclaw
dotnet run
```

Open `http://localhost:4050/` after the service starts.

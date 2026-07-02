# NiumaClaw 下载加速部署说明

NiumaClaw 客户端下载分为两类：

- 静态模板包：`/downloads/niumaclaw-agent-windows.exe`、`/downloads/niumaclaw-macos-agent.dmg`
- 账号专属包：`/generated-downloads/<token>/<file>`，由服务端生成后交给静态下载层发送

生产环境应尽量避免让应用进程直接传几十 MB 的 EXE/DMG 文件。推荐让 nginx、CDN 或对象存储承接大文件下载。

发布包会同时包含模板原文件名和公开下载别名：

- `NiumaClaw-Agent-Windows-template.exe` -> `niumaclaw-agent-windows.exe`
- `NiumaClaw-macOS-Agent-template.dmg` -> `niumaclaw-macos-agent.dmg`

nginx 和 CDN 应优先暴露公开下载别名。

## 1. nginx 静态直传

在 nginx 站点配置中增加：

```nginx
location ^~ /downloads/ {
    alias /opt/niumaclaw/current/team/downloads/;
    types {
        application/x-apple-diskimage dmg;
        application/vnd.microsoft.portable-executable exe;
    }
    default_type application/octet-stream;
    add_header Cache-Control "public, max-age=300";
    add_header X-Content-Type-Options "nosniff";
    try_files $uri =404;
}

location ^~ /generated-downloads/ {
    alias /opt/niumaclaw/shared/generated-downloads/;
    types {
        application/x-apple-diskimage dmg;
        application/vnd.microsoft.portable-executable exe;
    }
    default_type application/octet-stream;
    add_header Cache-Control "no-store, no-cache, max-age=0";
    add_header X-Content-Type-Options "nosniff";
    try_files $uri =404;
}
```

验证：

```bash
nginx -t
systemctl reload nginx
curl -I https://niuma.wiki/downloads/niumaclaw-agent-windows.exe
curl -I https://niuma.wiki/downloads/niumaclaw-macos-agent.dmg
```

应看到 `Content-Length`、`Accept-Ranges` 和正确的文件类型。

## 2. CDN 或对象存储域名

如果 CDN 或对象存储可以访问同样的路径前缀，配置：

```bash
NIUMACLAW_DOWNLOAD_PUBLIC_BASE_URL=https://download.niuma.wiki
```

服务端会把元数据和生成包重定向 URL 输出为：

```text
https://download.niuma.wiki/downloads/...
https://download.niuma.wiki/generated-downloads/...
```

注意：账号专属包包含节点 token，路径应保持短期有效，不建议长时间公开缓存。

## 3. 验收标准

- 点击 Windows/macOS 下载后，浏览器下载栏立即出现文件名。
- 静态包下载由 nginx/CDN 返回，不进入应用日志里的大文件传输。
- 账号专属包先由应用生成，再 302 到 `/generated-downloads/...`。
- 下载弹窗显示当前下载通道。
- 大文件支持断点续传或至少由静态层稳定传输。

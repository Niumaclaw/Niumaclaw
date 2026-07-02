# macOS Signing and Notarization

NiumaClaw Agent 的 macOS 商业化包需要先对 `.app` 做 Developer ID 签名和 notarization，再把已经 stapled 的 App 放入账号专属 DMG。因为服务端会把节点配置写入每个用户下载的 DMG，优先保证 `.app` 本体已签名、公证和 staple，避免个性化 DMG 破坏容器级签名。

## 前置条件

- Apple Developer Program 账号。
- 本机钥匙串已安装 `Developer ID Application` 证书。
- Xcode Command Line Tools 可用。
- 已配置 notarytool 凭据，推荐 keychain profile。

## 推荐配置

```bash
xcrun notarytool store-credentials "niumaclaw-notary" \
  --apple-id "APPLE_ID_EMAIL" \
  --team-id "TEAM_ID" \
  --password "APP_SPECIFIC_PASSWORD"
```

然后构建：

```bash
export MACOS_SIGN_IDENTITY="Developer ID Application: Your Company (TEAM_ID)"
export MACOS_NOTARY_KEYCHAIN_PROFILE="niumaclaw-notary"
./NiumaClaw.Agent/Packaging/create_desktop_client_templates.sh
```

## CI 环境变量

也可以不用 keychain profile，直接在 CI 中注入：

```bash
export MACOS_SIGN_IDENTITY="Developer ID Application: Your Company (TEAM_ID)"
export MACOS_NOTARY_APPLE_ID="APPLE_ID_EMAIL"
export MACOS_NOTARY_TEAM_ID="TEAM_ID"
export MACOS_NOTARY_PASSWORD="APP_SPECIFIC_PASSWORD"
```

## 输出文件

- `downloads/NiumaClaw-macOS-Agent-template.dmg`
- `downloads/NiumaClaw-Agent-Windows-template.exe`

macOS 脚本会执行：

- `codesign --options runtime` 对 App 启用 hardened runtime。
- `xcrun notarytool submit --wait` 提交 App zip。
- `xcrun stapler staple` 把公证票据固定到 App。
- `xcrun stapler validate` 验证 App。

## 验证

```bash
codesign --verify --deep --strict --verbose=2 "artifacts/native-desktop-client/dmg-root/NiumaClaw Agent.app"
xcrun stapler validate "artifacts/native-desktop-client/dmg-root/NiumaClaw Agent.app"
spctl -a -t exec -vv "artifacts/native-desktop-client/dmg-root/NiumaClaw Agent.app"
```

如果需要分发一个不写入账号配置的通用 DMG，可以额外设置：

```bash
export MACOS_NOTARIZE_DMG=1
```

账号专属 DMG 会被服务端写入配置，不建议依赖 DMG 容器本身的 notarization 状态；应依赖内部 App 的签名和 stapled ticket。


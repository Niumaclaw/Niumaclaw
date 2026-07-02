#!/usr/bin/env bash
set -euo pipefail

ROOT_DIR="$(cd "$(dirname "$0")/../.." && pwd)"
PROJECT="$ROOT_DIR/NiumaClaw.Agent/NiumaClaw.Agent.csproj"
OUTPUT_DIR="$ROOT_DIR/downloads"
BUILD_DIR="$ROOT_DIR/artifacts/native-desktop-client"
DOTNET_BIN="${DOTNET_BIN:-dotnet}"

MAC_RID="${MAC_RID:-osx-arm64}"
WIN_RID="${WIN_RID:-win-x64}"
MAC_PUBLISH="$BUILD_DIR/publish/$MAC_RID"
WIN_PUBLISH="$BUILD_DIR/publish/$WIN_RID"
DMG_ROOT="$BUILD_DIR/dmg-root"
APP_DIR="$DMG_ROOT/NiumaClaw Agent.app"
CONFIG_FILE="$DMG_ROOT/NiumaClaw Agent.config.b64"
ICON_SOURCE="$ROOT_DIR/NiumaClaw.Team.avatar_default_01.png"
ICONSET="$BUILD_DIR/AppIcon.iconset"

mkdir -p "$OUTPUT_DIR" "$BUILD_DIR"
rm -rf "$MAC_PUBLISH" "$WIN_PUBLISH" "$DMG_ROOT"

"$DOTNET_BIN" publish "$PROJECT" -c Release -r "$MAC_RID" --self-contained true -o "$MAC_PUBLISH" \
  /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:DebugType=None /p:DebugSymbols=false \
  /p:PublishTrimmed=true /p:TrimMode=partial

"$DOTNET_BIN" publish "$PROJECT" -c Release -r "$WIN_RID" --self-contained true -o "$WIN_PUBLISH" \
  /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:DebugType=None /p:DebugSymbols=false \
  /p:PublishTrimmed=true /p:TrimMode=partial

mkdir -p "$APP_DIR/Contents/MacOS" "$APP_DIR/Contents/Resources"
cp -R "$MAC_PUBLISH"/. "$APP_DIR/Contents/MacOS/"
mv "$APP_DIR/Contents/MacOS/NiumaClaw.Agent" "$APP_DIR/Contents/MacOS/NiumaClaw Agent"
chmod +x "$APP_DIR/Contents/MacOS/NiumaClaw Agent"

if command -v sips >/dev/null 2>&1 && command -v iconutil >/dev/null 2>&1 && [[ -f "$ICON_SOURCE" ]]; then
  rm -rf "$ICONSET"
  mkdir -p "$ICONSET"
  sips -z 16 16 "$ICON_SOURCE" --out "$ICONSET/icon_16x16.png" >/dev/null
  sips -z 32 32 "$ICON_SOURCE" --out "$ICONSET/icon_16x16@2x.png" >/dev/null
  sips -z 32 32 "$ICON_SOURCE" --out "$ICONSET/icon_32x32.png" >/dev/null
  sips -z 64 64 "$ICON_SOURCE" --out "$ICONSET/icon_32x32@2x.png" >/dev/null
  sips -z 128 128 "$ICON_SOURCE" --out "$ICONSET/icon_128x128.png" >/dev/null
  sips -z 256 256 "$ICON_SOURCE" --out "$ICONSET/icon_128x128@2x.png" >/dev/null
  sips -z 256 256 "$ICON_SOURCE" --out "$ICONSET/icon_256x256.png" >/dev/null
  sips -z 512 512 "$ICON_SOURCE" --out "$ICONSET/icon_256x256@2x.png" >/dev/null
  sips -z 512 512 "$ICON_SOURCE" --out "$ICONSET/icon_512x512.png" >/dev/null
  sips -z 1024 1024 "$ICON_SOURCE" --out "$ICONSET/icon_512x512@2x.png" >/dev/null
  iconutil -c icns "$ICONSET" -o "$APP_DIR/Contents/Resources/AppIcon.icns"
fi

cat > "$APP_DIR/Contents/Info.plist" <<'PLIST'
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
  <key>CFBundleDevelopmentRegion</key>
  <string>zh_CN</string>
  <key>CFBundleExecutable</key>
  <string>NiumaClaw Agent</string>
  <key>CFBundleIdentifier</key>
  <string>wiki.niuma.agent</string>
  <key>CFBundleName</key>
  <string>NiumaClaw Agent</string>
  <key>CFBundleDisplayName</key>
  <string>NiumaClaw Agent</string>
  <key>CFBundleIconFile</key>
  <string>AppIcon</string>
  <key>CFBundlePackageType</key>
  <string>APPL</string>
  <key>CFBundleShortVersionString</key>
  <string>1.0.5</string>
  <key>CFBundleVersion</key>
  <string>6</string>
  <key>LSMinimumSystemVersion</key>
  <string>12.0</string>
  <key>NSHighResolutionCapable</key>
  <true/>
</dict>
</plist>
PLIST

ln -s /Applications "$DMG_ROOT/Applications"

python3 - "$CONFIG_FILE" <<'PY'
from pathlib import Path
import sys

capacity = 65536
path = Path(sys.argv[1])
path.write_text(
    "__NIUMACLAW_CONFIG_B64_START__" + ("#" * capacity) + "__NIUMACLAW_CONFIG_B64_END__",
    encoding="ascii",
)
path.chmod(0o644)
PY

cat > "$DMG_ROOT/首次打开说明.txt" <<'TXT'
NiumaClaw Agent 是真正的 macOS 桌面客户端。

推荐步骤：
1. 首次下载后，先保持这个磁盘映像窗口打开。
2. 双击“NiumaClaw Agent”启动一次，客户端会自动保存当前账号的连接配置。
3. 之后可以把“NiumaClaw Agent”拖到 Applications（应用程序）里长期使用。

如果 macOS 提示无法验证开发者，请在系统设置 > 隐私与安全性中允许打开，或右键点击 App 后选择“打开”。
要完全去掉这个系统提示，需要 Apple Developer ID 签名和公证。
TXT

if command -v codesign >/dev/null 2>&1; then
  codesign --force --deep --sign - "$APP_DIR" >/dev/null 2>&1 || true
fi

hdiutil create \
  -volname "NiumaClaw Agent" \
  -srcfolder "$DMG_ROOT" \
  -ov \
  -fs HFS+ \
  -format UDRW \
  "$OUTPUT_DIR/NiumaClaw-macOS-Agent-template.dmg"

cp -f "$WIN_PUBLISH/NiumaClaw.Agent.exe" "$OUTPUT_DIR/NiumaClaw-Agent-Windows-template.exe"
echo "$OUTPUT_DIR/NiumaClaw-macOS-Agent-template.dmg"
echo "$OUTPUT_DIR/NiumaClaw-Agent-Windows-template.exe"

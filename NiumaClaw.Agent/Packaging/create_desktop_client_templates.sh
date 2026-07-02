#!/usr/bin/env bash
set -euo pipefail

ROOT_DIR="$(cd "$(dirname "$0")/../.." && pwd)"
PROJECT="$ROOT_DIR/NiumaClaw.Agent/NiumaClaw.Agent.csproj"
OUTPUT_DIR="$ROOT_DIR/downloads"
BUILD_DIR="$ROOT_DIR/artifacts/native-desktop-client"
DOTNET_BIN="${DOTNET_BIN:-dotnet}"

AGENT_VERSION="${AGENT_VERSION:-1.0.7}"
AGENT_BUILD_NUMBER="${AGENT_BUILD_NUMBER:-8}"
MAC_RID="${MAC_RID:-osx-arm64}"
WIN_RID="${WIN_RID:-win-x64}"
MAC_PUBLISH="$BUILD_DIR/publish/$MAC_RID"
WIN_PUBLISH="$BUILD_DIR/publish/$WIN_RID"
DMG_ROOT="$BUILD_DIR/dmg-root"
APP_DIR="$DMG_ROOT/NiumaClaw Agent.app"
CONFIG_FILE="$DMG_ROOT/NiumaClaw Agent.config.b64"
ICON_SOURCE="$ROOT_DIR/NiumaClaw.Team.avatar_default_01.png"
ICONSET="$BUILD_DIR/AppIcon.iconset"
ENTITLEMENTS="$ROOT_DIR/NiumaClaw.Agent/Packaging/macos-entitlements.plist"
APP_ZIP="$BUILD_DIR/NiumaClaw-Agent.app.zip"
MAC_DMG="$OUTPUT_DIR/NiumaClaw-macOS-Agent-template.dmg"
MACOS_SIGN_IDENTITY="${MACOS_SIGN_IDENTITY:-}"
MACOS_NOTARY_KEYCHAIN_PROFILE="${MACOS_NOTARY_KEYCHAIN_PROFILE:-}"
MACOS_NOTARY_APPLE_ID="${MACOS_NOTARY_APPLE_ID:-}"
MACOS_NOTARY_TEAM_ID="${MACOS_NOTARY_TEAM_ID:-}"
MACOS_NOTARY_PASSWORD="${MACOS_NOTARY_PASSWORD:-}"
MACOS_NOTARIZE_DMG="${MACOS_NOTARIZE_DMG:-0}"
NOTARY_ARGS=()

mkdir -p "$OUTPUT_DIR" "$BUILD_DIR"
rm -rf "$MAC_PUBLISH" "$WIN_PUBLISH" "$DMG_ROOT" "$APP_ZIP"

load_notary_args() {
  NOTARY_ARGS=()
  if [[ -n "$MACOS_NOTARY_KEYCHAIN_PROFILE" ]]; then
    NOTARY_ARGS=(--keychain-profile "$MACOS_NOTARY_KEYCHAIN_PROFILE")
    return 0
  fi

  if [[ -n "$MACOS_NOTARY_APPLE_ID" && -n "$MACOS_NOTARY_TEAM_ID" && -n "$MACOS_NOTARY_PASSWORD" ]]; then
    NOTARY_ARGS=(--apple-id "$MACOS_NOTARY_APPLE_ID" --team-id "$MACOS_NOTARY_TEAM_ID" --password "$MACOS_NOTARY_PASSWORD")
    return 0
  fi

  return 1
}

sign_macos_app() {
  if ! command -v codesign >/dev/null 2>&1; then
    echo "codesign not found; macOS app will not be signed." >&2
    return 0
  fi

  if [[ -z "$MACOS_SIGN_IDENTITY" ]]; then
    echo "MACOS_SIGN_IDENTITY is not set; using ad-hoc signing for local testing only." >&2
    codesign --force --deep --sign - "$APP_DIR" >/dev/null 2>&1 || true
    return 0
  fi

  while IFS= read -r -d '' file; do
    codesign --force --timestamp --options runtime --entitlements "$ENTITLEMENTS" --sign "$MACOS_SIGN_IDENTITY" "$file"
  done < <(find "$APP_DIR/Contents/MacOS" -type f -perm -111 -print0)

  codesign --force --timestamp --options runtime --entitlements "$ENTITLEMENTS" --sign "$MACOS_SIGN_IDENTITY" "$APP_DIR"
  codesign --verify --deep --strict --verbose=2 "$APP_DIR"
}

notarize_macos_app() {
  if [[ -z "$MACOS_SIGN_IDENTITY" ]]; then
    echo "Skipping notarization because MACOS_SIGN_IDENTITY is not set." >&2
    return 0
  fi
  if ! command -v xcrun >/dev/null 2>&1; then
    echo "xcrun not found; skipping notarization." >&2
    return 0
  fi

  load_notary_args || {
    echo "No notarization credentials configured; set MACOS_NOTARY_KEYCHAIN_PROFILE or Apple ID credentials." >&2
    return 0
  }

  ditto -c -k --keepParent "$APP_DIR" "$APP_ZIP"
  xcrun notarytool submit "$APP_ZIP" "${NOTARY_ARGS[@]}" --wait
  xcrun stapler staple "$APP_DIR"
  xcrun stapler validate "$APP_DIR"
}

maybe_notarize_dmg() {
  if [[ "$MACOS_NOTARIZE_DMG" != "1" || -z "$MACOS_SIGN_IDENTITY" ]]; then
    return 0
  fi
  if ! command -v xcrun >/dev/null 2>&1; then
    echo "xcrun not found; skipping DMG notarization." >&2
    return 0
  fi

  load_notary_args || {
    echo "No notarization credentials configured; skipping DMG notarization." >&2
    return 0
  }

  codesign --force --timestamp --sign "$MACOS_SIGN_IDENTITY" "$MAC_DMG"
  xcrun notarytool submit "$MAC_DMG" "${NOTARY_ARGS[@]}" --wait
  xcrun stapler staple "$MAC_DMG"
  xcrun stapler validate "$MAC_DMG"
}

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
  <string>__AGENT_VERSION__</string>
  <key>CFBundleVersion</key>
  <string>__AGENT_BUILD_NUMBER__</string>
  <key>LSMinimumSystemVersion</key>
  <string>12.0</string>
  <key>NSHighResolutionCapable</key>
  <true/>
</dict>
</plist>
PLIST

python3 - "$APP_DIR/Contents/Info.plist" "$AGENT_VERSION" "$AGENT_BUILD_NUMBER" <<'PY'
from pathlib import Path
import sys

path = Path(sys.argv[1])
text = path.read_text(encoding="utf-8")
text = text.replace("__AGENT_VERSION__", sys.argv[2]).replace("__AGENT_BUILD_NUMBER__", sys.argv[3])
path.write_text(text, encoding="utf-8")
PY

sign_macos_app
notarize_macos_app

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

正式发布包应已完成 Apple Developer ID 签名和公证。
如果这是本地测试包且 macOS 提示无法验证开发者，请在系统设置 > 隐私与安全性中允许打开，或右键点击 App 后选择“打开”。
TXT

hdiutil create \
  -volname "NiumaClaw Agent" \
  -srcfolder "$DMG_ROOT" \
  -ov \
  -fs HFS+ \
  -format UDRW \
  "$MAC_DMG"

maybe_notarize_dmg

cp -f "$WIN_PUBLISH/NiumaClaw.Agent.exe" "$OUTPUT_DIR/NiumaClaw-Agent-Windows-template.exe"
echo "$MAC_DMG"
echo "$OUTPUT_DIR/NiumaClaw-Agent-Windows-template.exe"

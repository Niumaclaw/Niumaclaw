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
CONFIG_FILE="$APP_DIR/Contents/Resources/NiumaClaw Agent.config.b64"

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
  <key>CFBundlePackageType</key>
  <string>APPL</string>
  <key>CFBundleShortVersionString</key>
  <string>1.0.0</string>
  <key>CFBundleVersion</key>
  <string>1</string>
  <key>LSMinimumSystemVersion</key>
  <string>12.0</string>
  <key>NSHighResolutionCapable</key>
  <true/>
</dict>
</plist>
PLIST

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

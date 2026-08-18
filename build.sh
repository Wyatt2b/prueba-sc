#!/bin/sh
curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh -c 10.0 -InstallDir ./dotnet
./dotnet/dotnet --version
./dotnet/dotnet publish -c Release -o output

# Crear _headers para Cloudflare Pages
cat > output/wwwroot/_headers << 'EOF'
/*
  X-Content-Type-Options: nosniff
  Cache-Control: public, max-age=31536000, immutable

/*.html
  Cache-Control: public, max-age=0, must-revalidate

/*.wasm
  Content-Type: application/wasm

/*.dll
  Content-Type: application/octet-stream

/*.dat
  Content-Type: application/octet-stream
EOF

echo "✓ _headers creado en output/wwwroot/"
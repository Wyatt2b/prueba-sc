#!/bin/sh
curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh -c 10.0 -InstallDir ./dotnet
./dotnet/dotnet --version
./dotnet/dotnet publish -c Release -o output

# Crear _headers con todos los MIME types necesarios para Blazor
cat > output/wwwroot/_headers << 'EOF'
/*
  Content-Type: text/html

/*.css
  Content-Type: text/css

/*.js
  Content-Type: application/javascript

/*.wasm
  Content-Type: application/wasm

/*.dll
  Content-Type: application/octet-stream

/*.dat
  Content-Type: application/octet-stream

/*.json
  Content-Type: application/json

/_framework/*
  Content-Type: application/octet-stream

/_framework/*.wasm
  Content-Type: application/wasm

/_framework/*.js
  Content-Type: application/javascript

/_framework/*.css
  Content-Type: text/css
EOF

# Asegurar que index.html tenga el base href correcto
sed -i 's/<base href="[^"]*"/<base href="\/"/g' output/wwwroot/index.html

echo "✓ _headers creado y index.html corregido"
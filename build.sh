#!/bin/sh
curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh -c 10.0 -InstallDir ./dotnet
./dotnet/dotnet --version
./dotnet/dotnet publish -c Release -o output

# ==============================================
# FORZAR COPIA DE _headers (SOLUCIÓN DEFINITIVA)
# ==============================================

# 1. Verificar si _headers existe en wwwroot
if [ -f "wwwroot/_headers" ]; then
    echo "✓ _headers encontrado en wwwroot"
    cp wwwroot/_headers output/wwwroot/
else
    echo "⚠️ _headers NO encontrado en wwwroot - Creando uno nuevo"
fi

# 2. Verificar que _headers existe en output
if [ -f "output/wwwroot/_headers" ]; then
    echo "✓ _headers copiado correctamente a output/wwwroot/"
    cat output/wwwroot/_headers
else
    echo "❌ ERROR: _headers NO está en output/wwwroot - Creándolo manualmente"
    cat > output/wwwroot/_headers << 'EOF'
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

/_framework/*
  Content-Type: application/octet-stream

/_framework/*.wasm
  Content-Type: application/wasm

/_framework/*.js
  Content-Type: application/javascript

/_framework/*.css
  Content-Type: text/css
EOF
    echo "✓ _headers creado manualmente en output/wwwroot/"
fi

# 3. Mostrar el contenido final
echo "=== CONTENIDO FINAL DE _headers ==="
cat output/wwwroot/_headers
echo "===================================="

echo "✓ Build completado"
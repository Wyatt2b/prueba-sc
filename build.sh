#!/bin/sh
curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh -c 10.0 -InstallDir ./dotnet
./dotnet/dotnet --version
./dotnet/dotnet publish -c Release -o output

# ==============================================
# MANEJAR FINGERPRINTING EN CLOUDFLARE PAGES
# ==============================================

# 1. Crear _headers con los MIME types correctos
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

# 2. Corregir el placeholder en index.html
if [ -f "output/wwwroot/index.html" ]; then
    echo "✓ Corrigiendo index.html..."
    # Reemplazar cualquier placeholder con el nombre real
    sed -i 's/blazor\.webassembly#[^{]*{fingerprint}/blazor.webassembly/g' output/wwwroot/index.html
    sed -i 's/blazor\.webassembly#[.{fingerprint}]/blazor.webassembly/g' output/wwwroot/index.html
    
    # Asegurar que base href sea /
    sed -i 's/<base href="[^"]*"/<base href="\/"/g' output/wwwroot/index.html
    echo "✓ index.html corregido"
fi

# 3. Copiar archivos fingerprinted a nombres sin fingerprint
if [ -d "output/wwwroot/_framework" ]; then
    echo "✓ Procesando archivos en _framework..."
    
    # Copiar cualquier archivo blazor.webassembly.*.js a blazor.webassembly.js
    for file in output/wwwroot/_framework/blazor.webassembly.*.js; do
        if [ -f "$file" ]; then
            cp "$file" "output/wwwroot/_framework/blazor.webassembly.js"
            echo "✓ Copiado: $(basename $file) → blazor.webassembly.js"
        fi
    done
    
    # Copiar cualquier archivo blazor.webassembly.*.css a blazor.webassembly.css
    for file in output/wwwroot/_framework/blazor.webassembly.*.css; do
        if [ -f "$file" ]; then
            cp "$file" "output/wwwroot/_framework/blazor.webassembly.css"
            echo "✓ Copiado: $(basename $file) → blazor.webassembly.css"
        fi
    done
fi

# 4. Verificar archivos importantes
echo "=== ARCHIVOS EN _framework ==="
ls -la output/wwwroot/_framework/ || echo "⚠️ _framework no existe"
echo "=============================="

echo "✓ Build completado"
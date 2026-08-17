# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar y restaurar dependencias
COPY ReforaTec.csproj .
RUN dotnet restore

# Copiar todo el código y publicar
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Servir con Nginx
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Copiar los archivos estáticos de Blazor
COPY --from=build /app/publish/wwwroot .

# Configurar Nginx para soportar SPA (Single Page Application)
RUN echo 'server { \
    listen 8080; \
    location / { \
        root /usr/share/nginx/html; \
        try_files $uri $uri/ /index.html =404; \
    } \
}' > /etc/nginx/conf.d/default.conf

EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]
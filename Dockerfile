# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar y restaurar dependencias
COPY ReforaTec.csproj .
RUN dotnet restore

# Copiar todo el código y publicar
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Verificar que el archivo existe (diagnóstico)
RUN ls -la /app/publish

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados
COPY --from=build /app/publish .

# Verificar que el archivo se copió (diagnóstico)
RUN ls -la /app

# Configurar puerto
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Comando de inicio
ENTRYPOINT ["dotnet", "ReforaTec.dll"]
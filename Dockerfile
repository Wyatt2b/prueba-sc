# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copiar el archivo del proyecto y restaurar dependencias
COPY ReforaTec.csproj .
RUN dotnet restore ReforaTec.csproj

# Copiar todo el código fuente y publicar la aplicación
COPY . .
RUN dotnet publish ReforaTec.csproj -c Release -o /app/publish

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "ReforaTec.dll"]
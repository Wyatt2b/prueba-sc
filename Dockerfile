# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copiar solo los archivos del proyecto
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del código
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "ReforaTec.dll"]
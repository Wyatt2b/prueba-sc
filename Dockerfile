# Etapa de compilación usando el SDK de .NET 10
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia todo el contenido del proyecto
COPY . .

# Restaura las dependencias y compila
RUN dotnet restore "ReforaTec.csproj"
RUN dotnet publish "ReforaTec.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa de ejecución final usando ASP.NET Core 10
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080

# Copia los archivos publicados desde la etapa anterior
COPY --from=build /app/publish .

# Ejecuta la aplicación usando la DLL principal
ENTRYPOINT ["dotnet", "ReforaTec.dll"]
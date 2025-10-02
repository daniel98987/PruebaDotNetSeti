# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Copiar csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore
# Copiar todo el código y compilar
COPY . ./
RUN dotnet publish -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
# Variables de entorno para ASP.NET Core
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080
# Puerto por defecto en contenedor
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "TranslatorJsonAndXml.dll"]

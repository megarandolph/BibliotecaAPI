# Etapa 1: Construcción de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar los archivos del proyecto y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o /out

# Etapa 2: Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copiar los archivos compilados desde la etapa de construcción
COPY --from=build-env /out .

# Configurar la aplicación para escuchar en el puerto 80
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "bibliotecaAPI.dll"]

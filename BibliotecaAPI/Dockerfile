# Etapa 1: Construcción de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src

# Copiar el archivo .csproj y restaurar dependencias
COPY ["BibliotecaAPI/BibliotecaAPI.csproj", "BibliotecaAPI/"]
RUN dotnet restore "BibliotecaAPI/BibliotecaAPI.csproj"

# Copiar el resto de los archivos y compilar
COPY . .
WORKDIR "/src/BibliotecaAPI"
RUN dotnet build "BibliotecaAPI.csproj" -c Release -o /app/build

# Publicar la aplicación
RUN dotnet publish "BibliotecaAPI.csproj" -c Release -o /app/publish

# Etapa 2: Imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "BibliotecaAPI.dll"]

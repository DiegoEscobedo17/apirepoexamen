# Establecer la imagen base de .NET 7.0.202
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar los archivos del proyecto y restaurar las dependencias
COPY *.csproj .
RUN dotnet restore

# Copiar el resto de los archivos y compilar la aplicación
COPY . .
RUN dotnet publish

# Configurar el contenedor final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Exponer el puerto necesario para la aplicación ASP.NET
EXPOSE 80

# Iniciar la aplicación ASP.NET
ENTRYPOINT ["dotnet", "ApiExamenesFinal2.dll"]

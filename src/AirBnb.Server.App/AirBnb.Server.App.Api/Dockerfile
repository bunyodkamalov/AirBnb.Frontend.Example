FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AirBnb.Server.App.Api/AirBnb.Server.App.Api.csproj", "AirBnb.Server.App.Api/"]
RUN dotnet restore "AirBnb.Server.App.Api/AirBnb.Server.App.Api.csproj"
COPY . .
WORKDIR "/src/AirBnb.Server.App.Api"
RUN dotnet build "AirBnb.Server.App.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AirBnb.Server.App.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AirBnb.Server.App.Api.dll"]

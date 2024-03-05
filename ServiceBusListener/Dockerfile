FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceBusListener/ServiceBusListener.csproj", "ServiceBusListener/"]
COPY ["ServiceBusListener.Common/ServiceBusListener.Common.csproj", "ServiceBusListener.Common/"]
RUN dotnet restore "ServiceBusListener/ServiceBusListener.csproj"
COPY . .
WORKDIR "/src/ServiceBusListener"
RUN dotnet build "ServiceBusListener.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ServiceBusListener.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceBusListener.dll"]

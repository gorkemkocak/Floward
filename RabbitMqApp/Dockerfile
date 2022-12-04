FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RabbitMqApp/RabbitMqApp.csproj", "RabbitMqApp/"]
RUN dotnet restore "RabbitMqApp/RabbitMqApp.csproj"
COPY . .
WORKDIR "/src/RabbitMqApp"
RUN dotnet build "RabbitMqApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitMqApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitMqApp.dll"]

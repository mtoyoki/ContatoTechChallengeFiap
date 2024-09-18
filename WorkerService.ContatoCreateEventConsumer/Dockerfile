#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WorkerService.ContatoCreateEventConsumer/WorkerService.ContatoCreateEventConsumer.csproj", "WorkerService.ContatoCreateEventConsumer/"]
COPY ["Infrastructure/Infra.Data.csproj", "Infrastructure/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["IoC/IoC.csproj", "IoC/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infra.Event.Publisher/Infra.EventPublisher.csproj", "Infra.Event.Publisher/"]
RUN dotnet restore "./WorkerService.ContatoCreateEventConsumer/WorkerService.ContatoCreateEventConsumer.csproj"
COPY . .
WORKDIR "/src/WorkerService.ContatoCreateEventConsumer"
RUN dotnet build "./WorkerService.ContatoCreateEventConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WorkerService.ContatoCreateEventConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerService.ContatoCreateEventConsumer.dll"]
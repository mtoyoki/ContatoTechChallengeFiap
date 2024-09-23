#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Service.ContatoDeleteQueueConsumer/Service.ContatoDeleteQueueConsumer.csproj", "Service.ContatoDeleteQueueConsumer/"]
COPY ["IoC/IoC.csproj", "IoC/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infra.Data/Infra.Data.csproj", "Infra.Data/"]
COPY ["Infra.QueuePublisher/Infra.QueuePublisher.csproj", "Infra.QueuePublisher/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "./Service.ContatoDeleteQueueConsumer/Service.ContatoDeleteQueueConsumer.csproj"
COPY . .
WORKDIR "/src/Service.ContatoDeleteQueueConsumer"
RUN dotnet build "./Service.ContatoDeleteQueueConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Service.ContatoDeleteQueueConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.ContatoDeleteQueueConsumer.dll"]
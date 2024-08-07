#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y tzdata
RUN mkdir -p /app/wwwroot && \
    chmod 755 /app/wwwroot
WORKDIR /app
EXPOSE 8080
ENV TZ=America/Costa_Rica

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InvenTrackCore.Api/InvenTrackCore.Api.csproj", "InvenTrackCore.Api/"]
COPY ["InvenTrackCore.Application/InvenTrackCore.Application.csproj", "InvenTrackCore.Application/"]
COPY ["InvenTrackCore.Domain/InvenTrackCore.Domain.csproj", "InvenTrackCore.Domain/"]
COPY ["InvenTrackCore.Utilities/InvenTrackCore.Utilities.csproj", "InvenTrackCore.Utilities/"]
COPY ["InvenTrackCore.Infrastructure/InvenTrackCore.Infrastructure.csproj", "InvenTrackCore.Infrastructure/"]
RUN dotnet restore "./InvenTrackCore.Api/InvenTrackCore.Api.csproj"
COPY . .
WORKDIR "/src/InvenTrackCore.Api"
RUN dotnet build "./InvenTrackCore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InvenTrackCore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chmod 755 /app
EXPOSE 8080
ENTRYPOINT ["dotnet", "InvenTrackCore.Api.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MSMS.Web/MSMS.Web.csproj", "MSMS.Web/"]
COPY ["MSMS.Infrastructure/MSMS.Infrastructure.csproj", "MSMS.Infrastructure/"]
COPY ["MSMS.Core/MSMS.Core.csproj", "MSMS.Core/"]
RUN dotnet restore "MSMS.Web/MSMS.Web.csproj"
COPY . .
WORKDIR "/src/MSMS.Web"
RUN dotnet build "MSMS.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MSMS.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "MSMS.Web.dll" ]

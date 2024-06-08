FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Common/Common.Application/Common.Application.csproj", "Common/Common.Application/"]
COPY ["Common/Common.Domain/Common.Domain.csproj", "Common/Common.Domain/"]
COPY ["Common/Common.Infrastructure/Common.Infrastructure.csproj", "Common/Common.Infrastructure/"]
COPY ["Common/Common.Web/Common.Web.csproj", "Common/Common.Web/"]
COPY ["Betting/Betting.Application/Betting.Application.csproj", "Betting/Betting.Application/"]
COPY ["Betting/Betting.Domain/Betting.Domain.csproj", "Betting/Betting.Domain/"]
COPY ["Betting/Betting.Infrastructure/Betting.Infrastructure.csproj", "Betting/Betting.Infrastructure/"]
COPY ["Betting/Betting.Startup/Betting.Startup.csproj", "Betting/Betting.Startup/"]
COPY ["Betting/Betting.Web/Betting.Web.csproj", "Betting/Betting.Web/"]
RUN dotnet restore "Betting/Betting.Startup/Betting.Startup.csproj"
COPY . .
WORKDIR "/src/Betting/Betting.Startup"
RUN dotnet build "Betting.Startup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Betting.Startup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BettingSystem.Startup.Betting.dll"]
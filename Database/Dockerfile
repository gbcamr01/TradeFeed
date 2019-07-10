FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Database/Database.csproj", "Database/"]
RUN dotnet restore "Database/Database.csproj"
COPY . .
WORKDIR "/src/Database"
RUN dotnet build "Database.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Database.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Database.dll"]

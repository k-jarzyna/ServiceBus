FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ServiceBus/ServiceBus.csproj", "ServiceBus/"]
RUN dotnet restore "ServiceBus/ServiceBus.csproj"
COPY . .
WORKDIR "/src/ServiceBus"
RUN dotnet build "ServiceBus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceBus.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceBus.dll"]

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["RewardingSystem/RewardingSystem.csproj", "RewardingSystem/"]
RUN dotnet restore "RewardingSystem/RewardingSystem.csproj"
COPY . .
WORKDIR "/src/RewardingSystem"
RUN dotnet build "RewardingSystem.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RewardingSystem.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RewardingSystem.dll"]
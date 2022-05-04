FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5001

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["NewApp.csproj", "./"]
RUN dotnet restore "NewApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "NewApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewApp.dll"]

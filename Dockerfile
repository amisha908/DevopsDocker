#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyDockerDevopsApplication/MyDockerDevopsApplication.csproj", "MyDockerDevopsApplication/"]
RUN dotnet restore "MyDockerDevopsApplication/MyDockerDevopsApplication.csproj"
COPY . .
WORKDIR "/src/MyDockerDevopsApplication"
RUN dotnet build "MyDockerDevopsApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyDockerDevopsApplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyDockerDevopsApplication.dll"]
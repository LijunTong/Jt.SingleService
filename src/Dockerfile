#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 10001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Jt.Cms/Jt.Cms.csproj", "Jt.Cms/"]
COPY ["Jt.Cms.Service/Jt.Cms.Service.csproj", "Jt.Cms.Service/"]
COPY ["Jt.Cms.Data/Jt.Cms.Data.csproj", "Jt.Cms.Data/"]
COPY ["Jt.Cms.Core/Jt.Cms.Core.csproj", "Jt.Cms.Core/"]
COPY ["Jt.Cms.Lib/Jt.Cms.Lib.csproj", "Jt.Cms.Lib/"]
RUN dotnet restore "Jt.Cms/Jt.Cms.csproj"
COPY . .
WORKDIR "/src/Jt.Cms"
RUN dotnet build "Jt.Cms.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jt.Cms.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jt.Cms.dll", "--urls", "http://*:10001"]
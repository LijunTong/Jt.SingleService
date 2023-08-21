#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 10001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Jt.SingleService/Jt.SingleService.csproj", "Jt.SingleService/"]
COPY ["Jt.SingleService.Service.Cms.Service.csproj", "Jt.SingleService.Service/"]
COPY ["Jt.SingleService.DataCOPY ["Jt.SingleService.Core.Cms.Core.csproj", "Jt.SingleService.Core/"]
COPY ["Jt.SingleService.Lib/Jt.SingleService.Lib.csproj", "Jt.SingleService.Lib/"]
RUN dotnet restore "Jt.SingleService/Jt.SingleService.csproj"
COPY . .
WORKDIR "/src/Jt.SingleService"
RUN dotnet build "Jt.SingleService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jt.SingleService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jt.SingleService.dll", "--urls", "http://*:10001"]
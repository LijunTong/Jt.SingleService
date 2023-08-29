FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Jt.SingleService/Jt.SingleService.csproj"
RUN dotnet build "Jt.SingleService/Jt.SingleService.csproj" -c Release -o /app/build
RUN dotnet publish "Jt.SingleService/Jt.SingleService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 10000
ENTRYPOINT ["dotnet", "Jt.SingleService.dll", "--urls", "http://*:10000"]

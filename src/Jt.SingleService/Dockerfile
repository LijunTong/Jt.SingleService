FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# 将所有项目文件复制到容器中
COPY . .

# 恢复依赖项并构建、发布应用程序
RUN dotnet restore "Jt.SingleService/Jt.SingleService.csproj"
RUN dotnet publish "Jt.SingleService/Jt.SingleService.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 设置应用程序运行环境
WORKDIR /app/publish
EXPOSE 10000
ENTRYPOINT ["dotnet", "Jt.SingleService.dll", "--urls", "http://*:10000"]

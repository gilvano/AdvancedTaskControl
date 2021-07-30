#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/AdvancedTaskControl.gRPCService/AdvancedTaskControl.gRPCService.csproj", "src/AdvancedTaskControl.gRPCService/"]
RUN dotnet restore "src/AdvancedTaskControl.gRPCService/AdvancedTaskControl.gRPCService.csproj"
COPY . .
WORKDIR "/src/src/AdvancedTaskControl.gRPCService"
RUN dotnet build "AdvancedTaskControl.gRPCService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdvancedTaskControl.gRPCService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdvancedTaskControl.gRPCService.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG VERSION="3.1-alpine"

FROM mcr.microsoft.com/dotnet/aspnet:$VERSION  AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:$VERSION  AS build
WORKDIR /src
COPY ["src/AdvancedTaskControl.API/AdvancedTaskControl.API.csproj", "src/AdvancedTaskControl.API/"]
COPY ["src/AdvancedTaskControl.Data/AdvancedTaskControl.Data.csproj", "src/AdvancedTaskControl.Data/"]
COPY ["src/AdvancedTaskControl.Business/AdvancedTaskControl.Business.csproj", "src/AdvancedTaskControl.Business/"]
RUN dotnet restore "src/AdvancedTaskControl.API/AdvancedTaskControl.API.csproj"
COPY . .
WORKDIR "/src/src/AdvancedTaskControl.API"
RUN dotnet build "AdvancedTaskControl.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdvancedTaskControl.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdvancedTaskControl.API.dll"]
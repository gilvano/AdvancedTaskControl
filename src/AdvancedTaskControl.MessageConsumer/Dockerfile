#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG VERSION="3.1-alpine"

FROM mcr.microsoft.com/dotnet/aspnet:$VERSION  AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:$VERSION  AS build
WORKDIR /src
COPY ["src/AdvancedTaskControl.MessageConsumer/AdvancedTaskControl.MessageConsumer.csproj", "src/AdvancedTaskControl.MessageConsumer/"]
COPY ["src/AdvancedTaskControl.Data/AdvancedTaskControl.Data.csproj", "src/AdvancedTaskControl.Data/"]
COPY ["src/AdvancedTaskControl.Business/AdvancedTaskControl.Business.csproj", "src/AdvancedTaskControl.Business/"]
RUN dotnet restore "src/AdvancedTaskControl.MessageConsumer/AdvancedTaskControl.MessageConsumer.csproj"
COPY . .
WORKDIR "/src/src/AdvancedTaskControl.MessageConsumer"
RUN dotnet build "AdvancedTaskControl.MessageConsumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdvancedTaskControl.MessageConsumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdvancedTaskControl.MessageConsumer.dll"]
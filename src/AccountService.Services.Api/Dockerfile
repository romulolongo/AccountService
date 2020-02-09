#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80 

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

COPY src/AccountService.Services.Api/AccountService.Services.Api.csproj AccountService.Services.Api/
#COPY src/AccountService.Domain/AccountService.Domain.csproj AccountService.Domain/
#COPY src/AccountService.Infra.Data/AccountService.Infra.Data.csproj AccountService.Infra.Data/
#COPY src/AccountService.Infra.IoC/AccountService.Infra.IoC.csproj AccountService.Infra.IoC/
#COPY src/AccountService.Application/AccountService.Application.csproj AccountService.Application/

RUN dotnet restore AccountService.Services.Api/AccountService.Services.Api.csproj
COPY . .

WORKDIR /src/AccountService.Services.Api

RUN dotnet build AccountService.Services.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AccountService.Services.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AccountService.Services.Api.dll"]
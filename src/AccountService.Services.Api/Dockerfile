FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# --===\\ BASEBUILD // ===-- #
FROM basesdk AS basebuild

WORKDIR /src

COPY Nuget.config Nuget.config
# Projects
COPY Application/AccountService.Application/AccountService.Application.csproj AccountService.Application/
COPY AccountService.Domain/AccountService.Domain.csproj AccountService.Domain/
COPY AccountService.Infra.Data/AccountService.Infra.Data.csproj AccountService.Infra.Data/
COPY AccountService.Infra.IoC/AccountService.Infra.IoC.csproj AccountService.Infra.IoC/
COPY AccountService.Services.Api/AccountService.Services.Api.csproj AccountService.Services.Api/

# Build image runtime!
FROM microsoft/dotnet:aspnetcore-runtime
MAINTAINER romulo.perlotti@fh.com
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebApp.dll"]
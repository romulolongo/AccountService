FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/AccountService.Services.Api/AccountService.Services.Api.csproj", "src/AccountService.Services.Api/"]
RUN dotnet restore "src/AccountService.Services.Api/AccountService.Services.Api.csproj"
COPY . .
WORKDIR "/src/src/AccountService.Services.Api"
RUN dotnet build "AccountService.Services.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AccountService.Services.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AccountService.Services.Api.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Coffee.WebApi/Coffee.WebApi.csproj", "Coffee.WebApi/"]
RUN dotnet restore "src/Coffee.WebApi/Coffee.WebApi.csproj"
COPY . .
WORKDIR "/src/Coffee.WebApi"
RUN dotnet build "Coffee.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Coffee.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coffee.WebApi.dll"]

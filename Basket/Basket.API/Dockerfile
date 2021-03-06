#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Basket/Basket.API/Basket.API.csproj", "Basket/Basket.API/"]
#COPY ["Shared/Shared/Shared.csproj", "Shared/Shared/"]
#COPY ["Basket/Basket.Infra/Basket.Infra.csproj", "Basket/Basket.Infra/"]
#COPY ["Basket/Basket.Domain/Basket.Domain.csproj", "Basket/Basket.Domain/"]
#COPY ["Basket/Basket.Application/Basket.Application.csproj", "Basket/Basket.Application/"]
RUN dotnet restore "Basket/Basket.API/Basket.API.csproj"
COPY . .
WORKDIR "/src/Basket/Basket.API"
RUN dotnet build "Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.API.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Discount/Discount.API/Discount.API.csproj", "Discount/Discount.API/"]
#COPY ["Shared/Shared/Shared.csproj", "Shared/Shared/"]
#COPY ["Discount/Discount.Domain/Discount.Domain.csproj", "Discount/Discount.Domain/"]
#COPY ["../Discount.Infra/Discount.Infra.csproj", "../Discount.Infra/"]
#COPY ["Discount/Discount.Application/Discount.Application.csproj", "Discount/Discount.Application/"]
RUN dotnet restore "Discount/Discount.API/Discount.API.csproj"
COPY . .
WORKDIR "/src/Discount/Discount.API"
RUN dotnet build "Discount.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.API.dll"]

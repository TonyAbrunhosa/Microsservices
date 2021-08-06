#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Discount/Discount.Grpc/Discount.Grpc.csproj", "Discount/Discount.Grpc/"]
#COPY ["Shared/Shared/Shared.csproj", "Shared/Shared/"]
#COPY ["Discount/Discount.Domain/Discount.Domain.csproj", "Discount/Discount.Domain/"]
#COPY ["Discount/Discount.Application/Discount.Application.csproj", "Discount/Discount.Application/"]
#COPY ["Discount/Discount.Infra/Discount.Infra.csproj", "Discount/Discount.Infra/"]
RUN dotnet restore "Discount/Discount.Grpc/Discount.Grpc.csproj"
COPY . .
WORKDIR "/src/Discount/Discount.Grpc"
RUN dotnet build "Discount.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.Grpc.dll"]

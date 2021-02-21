#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#https://dotnet.microsoft.com/download/dotnet-core?utm_source=getdotnetcorecli&utm_medium=referral
#https://docs.microsoft.com/zh-cn/dotnet/core/install/linux-centos
#docker build -t Product:v1 .
#docker run -t -d -p 80:5001 Product:v1
#down 
#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
#WORKDIR /app

#linux docker It was not possible to find any compatible framework version
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
#FROM mcr.microsoft.com/dotnet/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 7000
#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build


FROM base AS final
WORKDIR /app
COPY  . /app/out/Product
WORKDIR /app/out/Product 
ENTRYPOINT ["dotnet", "Shop.Product.Api.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 5000
ENV PLUTO=https://+:5001;http://+:5000
ENV ASPNETCORE_URLS=https://+:5001;http://+:5000
ENV PAPERINO="https://+:5001;http://+:5000"
ENV PIPPO="PIPPOPIPPO1"

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ShList.RestApi/ShList.RestApi.csproj", "ShList.RestApi/"]
RUN dotnet restore "ShList.RestApi/ShList.RestApi.csproj"
COPY . .
WORKDIR "/src/ShList.RestApi"
RUN dotnet build "ShList.RestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShList.RestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShList.RestApi.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["customer_complaint_service/customer_complaint_service.csproj", "customer_complaint_service/"]
RUN dotnet restore "customer_complaint_service/customer_complaint_service.csproj"
COPY . .
WORKDIR "/src/customer_complaint_service"
RUN dotnet build "customer_complaint_service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "customer_complaint_service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "customer_complaint_service.dll"]
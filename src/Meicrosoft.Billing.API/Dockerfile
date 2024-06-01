FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Meicrosoft.Billing.API/Meicrosoft.Billing.API.csproj", "src/Meicrosoft.Billing.API/"]
COPY ["src/Meicrosoft.Billing.Application/Meicrosoft.Billing.Application.csproj", "src/Meicrosoft.Billing.Application/"]
COPY ["src/Meicrosoft.Billing.Domain/Meicrosoft.Billing.Domain.csproj", "src/Meicrosoft.Billing.Domain/"]
COPY ["src/Meicrosoft.Billing.Infra.CrossCutting/Meicrosoft.Billing.Infra.CrossCutting.csproj", "src/Meicrosoft.Billing.Infra.CrossCutting/"]
COPY ["src/Meicrosoft.Billing.Infra/Meicrosoft.Billing.Infra.csproj", "src/Meicrosoft.Billing.Infra/"]
RUN dotnet restore "./src/Meicrosoft.Billing.API/./Meicrosoft.Billing.API.csproj"
COPY . .
WORKDIR "/src/src/Meicrosoft.Billing.API"
RUN dotnet build "./Meicrosoft.Billing.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Meicrosoft.Billing.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Meicrosoft.Billing.API.dll"]
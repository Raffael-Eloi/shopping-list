FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./src/ShoppingList.API/ShoppingList.API.csproj", "ShoppingList.API/"]
RUN dotnet restore "ShoppingList.API/ShoppingList.API.csproj"
COPY . .

WORKDIR "/src/src/ShoppingList.API"
RUN dotnet build "ShoppingList.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingList.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingList.API.dll"]
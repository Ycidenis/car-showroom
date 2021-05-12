FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarShowroom/CarShowroom.csproj", "CarShowroom/"]
RUN dotnet restore "CarShowroom/CarShowroom.csproj"
COPY . .
WORKDIR "/src/CarShowroom"
RUN dotnet build "CarShowroom.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarShowroom.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarShowroom.dll"]

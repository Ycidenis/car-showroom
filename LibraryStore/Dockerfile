FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["LibraryStore/LibraryStore.csproj", "LibraryStore/"]
RUN dotnet restore "LibraryStore/LibraryStore.csproj"
COPY . .
WORKDIR "/src/LibraryStore"
RUN dotnet build "LibraryStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryStore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryStore.dll"]

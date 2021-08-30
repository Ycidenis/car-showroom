FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["EmployeeProject/EmployeeProject.csproj", "EmployeeProject/"]
RUN dotnet restore "EmployeeProject/EmployeeProject.csproj"
COPY . .
WORKDIR "/src/EmployeeProject"
RUN dotnet build "EmployeeProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeProject.dll"]

FROM microsoft/aspnetcore:2.0.8 AS base
WORKDIR /app
EXPOSE 56377

FROM microsoft/aspnetcore-build:2.0.8-2.1.200 AS build
WORKDIR /src
COPY MVC/MVC.csproj MVC/
RUN dotnet restore MVC/MVC.csproj
COPY . .
WORKDIR /src/MVC
RUN dotnet build MVC.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MVC.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MVC.dll"]

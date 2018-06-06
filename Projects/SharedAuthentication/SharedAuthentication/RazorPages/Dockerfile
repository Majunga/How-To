FROM microsoft/aspnetcore:2.0.8 AS base
WORKDIR /app
EXPOSE 55750

FROM microsoft/aspnetcore-build:2.0.8-2.1.200 AS build
WORKDIR /src
COPY RazorPages/RazorPages.csproj RazorPages/
RUN dotnet restore RazorPages/RazorPages.csproj
COPY . .
WORKDIR /src/RazorPages
RUN dotnet build RazorPages.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RazorPages.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RazorPages.dll"]

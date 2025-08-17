# --- Build Stage ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY *.sln .
COPY Ludrary/Ludrary.csproj ./Ludrary/
RUN dotnet restore

COPY . .
WORKDIR /source/Ludrary
RUN dotnet publish -c Release -o /app/publish --no-restore

# --- Final Stage ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .


ENV ASPNETCORE_URLS=http://+:$PORT

ENTRYPOINT ["dotnet", "Ludrary.dll"]
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Ludrary.csproj", "."]
RUN dotnet restore "Ludrary.csproj"

COPY . .
WORKDIR "/src/."

RUN dotnet build "Ludrary.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
WORKDIR /app
COPY --from=build /app/build .

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "Ludrary.dll"]
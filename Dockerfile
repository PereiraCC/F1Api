# Stage: Get dependencies
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

#Stage: Prod app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS prod
WORKDIR /app

COPY --from=build /app/out ./
EXPOSE 5001
ENTRYPOINT ["dotnet", "Formula1Api.dll"]

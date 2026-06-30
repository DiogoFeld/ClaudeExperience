#Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

#Stage 2 Publish
COPY ["NewOne.csproj", "."]
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

#Stage 3 Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080


ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "NewOne.dll"]


#docker build -t simple-api -f "d:\ClaudeExp\SimpleApi\SimpleApi\Dockerfile" "d:\ClaudeExp\SimpleApi\SimpleApi"
#docker run --rm -d -p 6060:8080 -e ASPNETCORE_ENVIRONMENT=Development --name simple-api simple-api
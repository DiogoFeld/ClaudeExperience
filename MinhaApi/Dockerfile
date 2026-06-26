# Estágio 1: imagem base de runtime (só o necessário para rodar, sem SDK)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Define o diretório de trabalho dentro do container
WORKDIR /app
# Informa ao Docker que o container escuta na porta 8080 (documentação, não abre a porta de fato)
EXPOSE 8080

# Estágio 2: imagem de build (contém o SDK completo para compilar o projeto)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Define o diretório de trabalho para o processo de build
WORKDIR /src
# Copia apenas o arquivo de projeto primeiro (otimiza cache: restore só roda se o .csproj mudar)
COPY ["MinhaApi.csproj", "."]
# Restaura as dependências NuGet declaradas no .csproj
RUN dotnet restore
# Copia todo o restante do código-fonte para o container
COPY . .
# Compila e publica em modo Release, saída em /app/publish; pula o restore pois já foi feito
RUN dotnet publish -c Release -o /app/publish --no-restore

# Estágio 3: imagem final, parte do estágio base (runtime leve, sem SDK)
FROM base AS final
# Define o diretório de trabalho na imagem final
WORKDIR /app
# Copia os artefatos publicados do estágio de build para a imagem final
COPY --from=build /app/publish .
# Define o comando que será executado quando o container iniciar
ENTRYPOINT ["dotnet", "MinhaApi.dll"]

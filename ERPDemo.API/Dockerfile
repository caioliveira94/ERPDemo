#Imagem de execução
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

#Nome do projeto
ARG COMPOSE_PROJECT_NAME

#Define o diretório de trabalho
WORKDIR "/${COMPOSE_PROJECT_NAME}"

#Copia tudo para pasta do workdir, faz o restore e copia os pacotes
COPY . .
RUN dotnet restore "${COMPOSE_PROJECT_NAME}.sln" --configfile NuGet.Config
COPY . .

#Define o diretório de trabalho sobre o projeto de API
WORKDIR /src
COPY ["ERPDemo.API/ERPDemo.API.csproj", "ERPDemo.API/"]
COPY ["ERPDemo.ApplicationService/ERPDemo.ApplicationService.csproj", "ERPDemo.ApplicationService/"]
COPY ["ERPDemo.Domain/ERPDemo.Domain.csproj", "ERPDemo.Domain/"]
COPY ["ERPDemo.Data/ERPDemo.Data.csproj", "ERPDemo.Data/"]
RUN dotnet restore "ERPDemo.API/ERPDemo.API.csproj"
COPY . .
WORKDIR "/src/ERPDemo.API"
RUN dotnet build "ERPDemo.API.csproj" -c Release -o /app/build

#Pela imagem de build, gera o deploy
FROM build AS publish
RUN dotnet publish "ERPDemo.API.csproj" -c Release -o /app/publish

#Copia o deploy para imagem base
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ERPDemo.API.dll"]
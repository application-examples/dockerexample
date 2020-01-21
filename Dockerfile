FROM mcr.microsoft.com/dotnet/core/sdk:2.1 as build

WORKDIR /app

COPY . .
RUN dotnet publish -c Release -o ./publish

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1

WORKDIR /app

COPY --from=build ./app/DockerMysqlDotnet/publish .

CMD ["dotnet", "DockerMysqlDotNet.dll"]
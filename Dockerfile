FROM mcr.microsoft.com/dotnet/core/sdk:2.1 as build

WORKDIR /app

COPY . .
RUN dotnet restore
RUN dotnet ef migrations add init --project ./DockerMysqlDotNet
RUN dotnet ef database update
RUN dotnet publish -c Release -o ./publish

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1

WORKDIR /app

COPY --from=build ./app/DockerMysqlDotnet/publish .

CMD ["dotnet", "DockerMysqlDotNet.dll"]
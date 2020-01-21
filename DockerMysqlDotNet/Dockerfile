FROM mcr.microsoft.com/dotnet/core/sdk:2.1 as migration

WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet ef migrations add init
RUN dotnet ef update database

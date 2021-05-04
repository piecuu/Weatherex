FROM mcr.microsoft.com/dotnet/sdk:3.1 AS publish

WORKDIR /src

EXPOSE 80

EXPOSE 443

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=publish /app/ .

ENTRYPOINT ["dotnet", "Weatherex.Api.dll"]
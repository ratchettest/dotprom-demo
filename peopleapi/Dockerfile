#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "peopleapi.csproj"
RUN dotnet publish -c Release -o /publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "peopleapi.dll"]

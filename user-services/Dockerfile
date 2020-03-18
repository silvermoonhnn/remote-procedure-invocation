FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-user
WORKDIR /source

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet 

WORKDIR /app
COPY --from=build-user /source/out ./
ENTRYPOINT ["dotnet", "user-services.dll"]

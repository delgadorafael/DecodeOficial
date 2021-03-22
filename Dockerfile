FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build-env 
WORKDIR /app

COPY DecodeOficial.API/DecodeOficial.API.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish DecodeOficial.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DecodeOficial.API.dll"]
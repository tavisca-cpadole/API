FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY TestAPI2/TestAPI2.csproj TestAPI2/
RUN dotnet restore TestAPI2/TestAPI2.csproj
COPY . .
WORKDIR /src/TestAPI2
RUN dotnet build TestAPI2.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TestAPI2.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestAPI2.dll"]

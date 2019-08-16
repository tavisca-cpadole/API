FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR app

COPY TestAPI2/Publish .

ENTRYPOINT ["dotnet", "TestAPI2.dll"]
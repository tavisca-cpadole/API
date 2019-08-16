FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR app

COPY TestAPI2/Publish .

EXPOSE 8083
ENTRYPOINT ["dotnet", "TestAPI2.dll"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
ARG publish_path
WORKDIR app

COPY $publish_path .

ENV SOLUTION_DLL="TestAPI2.dll"

ENTRYPOINT dotnet ${SOLUTION_DLL}
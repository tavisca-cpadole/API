ARG publish_path
ARG dll_name

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR app

COPY $publish_path .

ENTRYPOINT ["dotnet", "$dll_name"]

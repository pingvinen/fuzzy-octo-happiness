#
# Generates an image that can:
#  - build dotnet core projects
#  - run dotnet core projects
#
FROM microsoft/dotnet:2.2.103-sdk-alpine

WORKDIR /app
EXPOSE 5000

COPY ./src/main/main.csproj /app/src/main/
COPY ./src/test-unit/test-unit.csproj /app/src/test-unit/
COPY ./alala.sln /app/

RUN dotnet restore

COPY ./src/ /app/src/

# set up environment
ENV ASPNETCORE_ENVIRONMENT=Development

RUN dotnet build

ENTRYPOINT [ "dotnet", "run", "--project", "/app/src/main/main.csproj" ]

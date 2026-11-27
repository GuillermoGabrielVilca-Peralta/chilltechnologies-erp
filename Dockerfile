FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ChillTechnologies/ChillTechnologies.Domain/*.csproj         ChillTechnologies.Domain/
COPY ChillTechnologies/ChillTechnologies.Application/*.csproj    ChillTechnologies.Application/
COPY ChillTechnologies/ChillTechnologies.Infrastructure/*.csproj ChillTechnologies.Infrastructure/
COPY ChillTechnologies/ChillTechnologies.API/*.csproj            ChillTechnologies.API/
RUN dotnet restore ChillTechnologies.API/ChillTechnologies.API.csproj

COPY ChillTechnologies/ ./
RUN dotnet publish ChillTechnologies.API/ChillTechnologies.API.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

RUN apt-get update \
 && apt-get install -y --no-install-recommends tzdata \
 && rm -rf /var/lib/apt/lists/*

ENV TZ=America/Lima
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

COPY --from=build /app ./

ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080

ENTRYPOINT ["sh", "-c", "exec dotnet ChillTechnologies.API.dll --urls http://0.0.0.0:${PORT:-8080}"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserWebClient.csproj","./"]
RUN dotnet restore "UserWebClient.csproj"
COPY . .
RUN dotnet publish -c Release -o out

FROM base AS final
COPY --from=build /src/out .
ENTRYPOINT [ "dotnet","UserWebClient.dll" ]
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AppQuizz/AppQuizz.csproj", "AppQuizz/"]
RUN dotnet restore "AppQuizz/AppQuizz.csproj"

COPY . .
WORKDIR "/src/AppQuizz"
RUN dotnet build "AppQuizz.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppQuizz.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppQuizz.dll"]
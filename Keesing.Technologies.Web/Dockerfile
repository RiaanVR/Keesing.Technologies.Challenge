FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Keesing.Technologies.Web/Keesing.Technologies.Web.csproj", "Keesing.Technologies.Web/"]
RUN dotnet restore "Keesing.Technologies.Web/Keesing.Technologies.Web.csproj"
COPY . .
WORKDIR "/src/Keesing.Technologies.Web"
RUN dotnet build "Keesing.Technologies.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Keesing.Technologies.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Keesing.Technologies.Web.dll"]

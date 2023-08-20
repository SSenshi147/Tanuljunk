#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cats/Cats.csproj", "Cats/"]
RUN dotnet restore "Cats/Cats.csproj"
COPY . .
WORKDIR "/src/Cats"
RUN dotnet build "Cats.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cats.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cats.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Notes/Presentation.csproj", "Notes/"]
COPY ["Notes.BusinessLogic/Notes.BusinessLogic.csproj", "Notes.BusinessLogic/"]
COPY ["Notes.BusinessLogic.Abstraction/Notes.BusinessLogic.Abstraction.csproj", "Notes.BusinessLogic.Abstraction/"]
COPY ["Notes.Domain/Notes.Domain.csproj", "Notes.Domain/"]
COPY ["Notes.Repository/Notes.Repository.csproj", "Notes.Repository/"]
RUN dotnet restore "./Notes/Presentation.csproj"
COPY . .
WORKDIR "/src/Notes"
RUN dotnet build "./Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.dll"]
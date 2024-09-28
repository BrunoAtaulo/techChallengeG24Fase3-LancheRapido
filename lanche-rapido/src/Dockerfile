# Use the .NET 8 runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the .NET 8 SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY ["Api/Api.csproj", "Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infra/Infra.csproj", "Infra/"]

# Restore the project dependencies using the csproj of the API
RUN dotnet restore "Api/Api.csproj"

# Copy the rest of the source code
COPY . .

# Set the working directory to the API project and build the project
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

# Publish the build output
FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

# Final stage: Use the base image to run the application
FROM base AS final
WORKDIR /app

# Copy the published output to the final image
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Api.dll"]

# Use .NET 8 ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
 
# Use .NET 8 SDK for building the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
 
# Copy all the files from the current folder (where csproj and others reside)
COPY . .
 
# Run dotnet restore to restore dependencies
RUN dotnet restore "ChoresAPI.csproj"
 
# Build the project in Release mode
RUN dotnet build "ChoresAPI.csproj" -c Release -o /app/build
 
# Publish the project to the publish folder
FROM build AS publish
RUN dotnet publish "ChoresAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false
 
# Use the base runtime image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
 
# Set the entry point to run the application
ENTRYPOINT ["dotnet", "ChoresAPI.dll"]
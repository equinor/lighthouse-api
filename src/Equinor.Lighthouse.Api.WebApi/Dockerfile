FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy project files separately and restore NuGet packages to create layers. Skip test projects!
COPY Equinor.Lighthouse.Api.Command/*.csproj ./Equinor.Lighthouse.Api.Command/
COPY Equinor.Lighthouse.Api.Domain/*.csproj ./Equinor.Lighthouse.Api.Domain/
COPY Equinor.Lighthouse.Api.Infrastructure/*.csproj ./Equinor.Lighthouse.Api.Infrastructure/
COPY Equinor.Lighthouse.Api.MainApi/*.csproj ./Equinor.Lighthouse.Api.MainApi/
COPY Equinor.Lighthouse.Api.BlobStorage/*.csproj ./Equinor.Lighthouse.Api.BlobStorage/
COPY Equinor.Lighthouse.Api.Query/*.csproj ./Equinor.Lighthouse.Api.Query/
COPY Equinor.Lighthouse.Api.WebApi/*.csproj ./Equinor.Lighthouse.Api.WebApi/

# Copy full solution
COPY . .

# Set workdir where main project is
WORKDIR "/src/Equinor.Lighthouse.Api.WebApi"

# Build
ENV DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0
RUN dotnet build "Equinor.Lighthouse.Api.WebApi.csproj" -c Release

# Publish the application
FROM build AS publish
WORKDIR "/src/Equinor.Lighthouse.Api.WebApi"
RUN dotnet publish "Equinor.Lighthouse.Api.WebApi.csproj" -c Release --no-restore -o /app/publish

# Define the image used for the final result
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# Install System.Drawing native dependencies (added because of Excel export (ClosedXML library) support).
#RUN apt-get update
#RUN apt-get install -y libc6 libgdiplus
#RUN rm -rf /var/lib/apt/lists/*

# Create non-root user. Set ui to 9999 to avoid conflicts with host OS just in case
RUN adduser --disabled-password --uid 9999 --gecos "" apprunner

# Create the folder and set the non-root as owner
RUN mkdir /app && chown apprunner.apprunner /app

# Change the user from root to non-root- From now on, all Docker commands are run as non-root user (except for COPY)
USER apprunner

# Set the port to 5000 since the default production port is 80 and on-root users cannot bind to this port
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
WORKDIR /app

# Copy the published files from the build image into this one
# Copy defaults to copying files as root, specify the user that should be the owner
COPY --chown=apprunner:apprunner --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Equinor.Lighthouse.Api.WebApi.dll"]
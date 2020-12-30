FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
COPY . /app
WORKDIR /app 
RUN dotnet restore
RUN dotnet publish -c Release -o build "SQL/WebApplication.EFCore/WebApplication.EFCore.csproj"
    EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "build/WebApplication.EFCore.dll"]
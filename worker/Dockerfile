FROM mcr.microsoft.com/dotnet/core/sdk:2.1
WORKDIR /app
COPY worker.csproj /app/
RUN dotnet restore
COPY . /app
ENTRYPOINT ["dotnet", "run"]
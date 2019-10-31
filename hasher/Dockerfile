FROM mcr.microsoft.com/dotnet/core/sdk:2.1
WORKDIR /app
COPY hasher.csproj /app/
RUN dotnet restore
COPY . /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "run", "--no-launch-profile"]
FROM microsoft/dotnet:nanoserver
RUN mkdir /app
WORKDIR /app
COPY worker.csproj /app/
RUN dotnet restore
COPY . /app
ENTRYPOINT ["dotnet", "run"]
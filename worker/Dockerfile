FROM microsoft/dotnet:nanoserver
RUN mkdir /app
WORKDIR /app
COPY . /app
RUN dotnet restore
ENTRYPOINT ["dotnet", "run"]
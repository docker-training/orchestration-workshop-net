FROM microsoft/dotnet:nanoserver
RUN mkdir /app
WORKDIR /app
COPY rng.csproj /app/
RUN dotnet restore
COPY . /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]
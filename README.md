# Introduction
This is a port of Jerome Petazzo's [Docker Coins Workshop](https://github.com/docker-training/orchestration-workshop) to .NET Core and Windows Server Containers. For the UI we are using the `microsoft/nanoserver` based Node image provided by Stefan Scherrer: [https://github.com/StefanScherer/dockerfiles-windows/tree/master/node](https://github.com/StefanScherer/dockerfiles-windows/tree/master/node).

## Cloning the Repo
On the target computer clone the repo:

```bash
PS> git clone https://github.com/docker-training/orchestration-workshop-net.git
```

## Running the App on a single Node
Run:

```bash
PS> docker-compose up -d
```

## Viewing the UI
Open a browser and navigate to

```bash
http://<Public IP Address>:8000
```

Where `<Public IP Address>` is the public IP address of the computer your running the app. If it is locally then use `localhost`.

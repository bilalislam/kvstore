# distributed key-value & config store

## motivation

As an application stands up, as you all know, it is always based on a configuration file.This file contains all the data that we expect to be variable, sensitive and confidential for that application. In this project, we will examine how we have purified our dotnet core application from all the configuration information in a distributed, concurrent way.

## What is hashicorp vault ?

Vault is a tool for securely accessing secrets. A secret is anything that you want to tightly control access to, such as API keys, passwords, or certificates and configs. Vault provides a unified interface to any secret, while providing tight access control and recording a detailed audit log.

After the up this app , you can access vault ui from 8200 port and manage config from kv engines tabs.

### What is IPC_Lock ?
The container will attempt to lock memory to prevent sensitive values from being swapped to disk and as a result must have --cap-add=IPC_LOCK provided to docker run.

Note the --cap-add=IPC_LOCK: this is required in order for Vault to lock memory, which prevents it from being swapped to disk. 

## How to build for service-a

```sh
$ cd /docker/serviceA/
$ sh build.sh
```

## How to build for service-b

```sh
$ cd /docker/serviceB/
$ sh build.sh
```

## How to setup via docker compose:

```sh
$ cd /deploy/docker-compose
$ docker-compose up
```
For stop all containers
```sh
$ docker-compose down
```

## TTL 
coming soon ...

## Key versioning
coming soon ...

## Service Discovery 
coming soon ...

## road map
1. kvstore exception handling as lambda evaluation so not try-catch using per each method
2. use vault db
3. vault cluster management

## references 

1. https://www.vaultproject.io/docs


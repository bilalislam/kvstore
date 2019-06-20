#!/bin/bash

# Define image name and version
NAME_SPACE=ninjafx
IMAGE_NAME=service-a
VERSION=latest

# run build script for dockerfile
projectList=(
    "../../src/serviceA"
)

for project in "${projectList[@]}"
do
    echo -e "\e[33mWorking on $(pwd)/$project"
    echo -e "\e[33m\tRemoving old publish output"
    pushd $(pwd)/$project
    rm -rf obj/Docker/publish
    echo -e "\e[33m\tBuilding and publishing projects"
    dotnet restore
    dotnet build
    dotnet publish -o obj/Docker/publish -c Release
    popd
done

# Create and Copy latest built dll file into docker folder
mkdir app
mv ../../src/serviceA/obj/Docker/publish app/
rm -rf ../../src/serviceA/obj/Docker

# Build docker image
docker build -f Dockerfile -t "$IMAGE_NAME:$VERSION" .

# Tag this version as latest
docker tag $IMAGE_NAME $NAME_SPACE/$IMAGE_NAME:$VERSION

# Push docker image as latest
docker push "$NAME_SPACE/$IMAGE_NAME:$VERSION"

# Remove built jar file
rm -rf app
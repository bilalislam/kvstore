#!/bin/bash

while [ `curl -s -o /dev/null -w "%{http_code}" http://vault:8200` != 200 ]; do
    echo "waiting for enable vault"
    sleep 1
done

dotnet serviceB.dll
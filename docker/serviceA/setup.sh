#!/bin/bash

while [ `curl -s -o /dev/null -w "%{http_code}" http://vault:8200/` != 307 ]; do
    echo "waiting for enable vault"
    sleep 1
done

curl -XPOST --header "X-Vault-Token: my-root"  'http://vault:8200/v1/sys/mounts/kv' -d' {"path" :"kv","type":"kv"}'
dotnet serviceA.dll

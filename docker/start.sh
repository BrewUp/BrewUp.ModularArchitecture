#!/bin/bash
source .env

if [[ "$PLATFORM" == "arm64"* ]]; then
    export DOCKERFILE=Dockerfile.arm64
else
    export DOCKERFILE=Dockerfile.x64
fi

docker-compose up -d
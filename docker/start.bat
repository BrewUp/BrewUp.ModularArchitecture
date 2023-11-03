@echo off
setlocal
set DOCKERFILE=Dockerfile.x64
docker-compose up -d --build --remove-orphans
endlocal
# Come eseguire
Abbiamo preparato il docker compose in modo che sia in grado di creare l'eventstore per architetture x86 o ARM senza troppe modifiche. Per procedere seguire le istruzioni seguenti:

## Mac
Creare un file `.env` nella stessa cartella del docker-compose.yml e specificare l'architettura in utilizzo. Per esempio:

    PLATFORM=x64

I valori possibili sono due:

    x64
    arm64
    
Succesivamente basta eseguire (Mac serie M, ARM)

    sh start.sh

## Windows
Eseguire

    start.bat


# Modifica diretta del docker-compose.yml
Se volete modificarvi direttamente il docker compose sostituite il pezzo a riga 18

    build:
      dockerfile: ${DOCKERFILE}

con (Windows o Mac, x86)

    image: eventstore/eventstore:latest

oppure (Mac serie M, ARM)

    image: eventstore/eventstore:22.10.2-alpha-arm64v8

Per eseguirlo, lanciare

    docker compose up -d


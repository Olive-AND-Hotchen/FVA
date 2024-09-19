### COMMANDS ##

start : cleanup restore build docker-build docker-run
stop : docker-stop cleanup
migrate: start create-migration update-db
roll-back-migration: revert-migration remove-migration

### DOTNET ##

cleanup:
	dotnet clean FVA.sln
 
restore:
	dotnet restore FVA.sln
 
build:
	dotnet build FVA.sln

format:
	dotnet format FVA.sln
 
run-client:
	dotnet run --project Client/Client.csproj

run-server:
	dotnet run --project Server/Server.csproj

create-migration:
	dotnet ef migrations add $(migration_name) --project Server/Server.csproj

update-db:
	dotnet ef database update --project Server/Server.csproj

revert-migration:
	dotnet ef database update $(previous_migration) --project Server/Server.csproj

remove-migration:
	dotnet ef migrations remove --project Server/Server.csproj

### DOCKER ###

docker-build:
	docker build -t fva:server -f Dockerfile-Server .
	docker build -t fva:client -f Dockerfile-Client .

docker-run:
	docker compose up -d

docker-stop:
	docker compose down
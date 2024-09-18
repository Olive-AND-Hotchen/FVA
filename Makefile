### COMMANDS ##

start : cleanup restore build docker-build docker-run
stop : docker-stop cleanup
migrate: start create-migration update-db
roll-back-migration: revert-migration remove-migration

### DOTNET ##

cleanup:
	dotnet clean Server/Server.csproj
	dotnet clean Client/Client.csproj
 
restore:
	dotnet restore Server/Server.csproj
	dotnet restore Client/Client.csproj
 
build:
	dotnet build Server/Server.csproj
	dotnet build Client/Client.csproj

format:
	dotnet format Server/Server.csproj
	dotnet format Client/Client.csproj
 
run:
	dotnet run -p Server/Server.csproj
	dotnet run -p Client/Client.csproj

create-migration:
	dotnet ef migrations add $(migration_name)

update-db:
	dotnet ef database update

revert-migration:
	dotnet ef database update $(previous_migration)

remove-migration:
	dotnet ef migrations remove

### DOCKER ###

docker-build:

	docker build -t registry/server server

	docker build -t registry/client client

docker-run:
	docker compose up -d

docker-stop:
	docker compose down
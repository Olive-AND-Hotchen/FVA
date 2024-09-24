### COMMANDS ##

start-dev : cleanup restore docker-build-dev docker-run
start-release : cleanup restore docker-build-release docker-run
stop : docker-stop cleanup
migrate: start-dev create-migration update-db
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
	

dev-cert:
	dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p fva_password
	dotnet dev-certs https --trust

### DOCKER ###

docker-build-dev:
	docker build --no-cache -t fva:server -f Dockerfile-Server --build-arg ENV=Debug .
	docker build --no-cache -t fva:client -f Dockerfile-Client --build-arg ENV=Debug .

docker-build-release:
	docker build --no-cache -t fva:server -f Dockerfile-Server --build-arg ENV=Release .
	docker build --no-cache -t fva:client -f Dockerfile-Client --build-arg ENV=Release .

docker-run:
	docker compose up

docker-stop:
	docker compose down
### COMMANDS ##

start : cleanup restore build docker-build docker-run
stop : docker-stop cleanup
migrate: start create-migration update-db
roll-back-migration: revert-migration remove-migration

### DOTNET ##

cleanup:
	dotnet clean FVA.csproj
 
restore:
	dotnet restore FVA.csproj
 
build:
	dotnet build FVA.csproj

format:
	dotnet format FVA.csproj
 
run:
	dotnet run -p FVA.csproj

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
	docker build -t fva .

docker-run:
	docker compose up -d

docker-stop:
	docker compose down




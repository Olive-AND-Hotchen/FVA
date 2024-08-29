start : cleanup restore build docker-build docker-run
stop : docker-stop cleanup
 
cleanup:
	dotnet clean FVA.csproj
 
restore:
	dotnet restore FVA.csproj
 
build:
	dotnet build FVA.csproj
 
run:
	dotnet run -p FVA.csproj

docker-build:
	docker build -t fva .

docker-run:
	docker run -dp 8080:8080 fva

docker-stop:
	docker stop fva
	docker rm fva
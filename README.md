# FVA

## Prerequisites
**dotnet 8**:
https://dotnet.microsoft.com/en-us/download/dotnet/8.0

**docker**: https://www.docker.com/


# Commands
This project uses a [Makefile](Makefile) to run commands. Any command can be run with 
``make {COMMAND}``.

## Commands

### **start**
``` bash
make start
```
#### **Description**
Runs several commands to bring up the stack, api and db.

### **stop**
``` bash
make stop
```
#### **Description**
Stop the api and remove containers.


### **cleanup**
``` bash
make cleanup
```
#### **Description**
Cleans the output of the project from the previous build. Project targeted: (``FVA.csproj``).

Whilst not required everytime the project is built, it can help in resolving dotnet specific problems when assemblies may not work correctly.

### **restore**
```bash
make restore
```

#### **Description**
Goes through the NuGet dependencies and downloads any missing dependencies or updates out of date dependencies.

### **build**
```bash
make build
```

#### **Description**
Build the dotnet project, creating dll files in the bin/debug folder along with the executable. 

### **run**
```bash
make run
```

#### **Description**
Runs the application.

### **docker-build**
```bash
make docker-build
```

#### **Description**
Build the image based on mcr.microsoft.com/dotnet/aspnet:8.0

### **docker-run**
```bash
make docker-run
```

#### **Description**
Runs the build image and creates a container. Runs on port 8080

### **docker-stop**
```bash
make docker-stop
```

#### **Description**
Tears down the container.


### **migrate**
```bash
make migrate migration_name={MIGRATION_NAME}
```

#### **Description**
Creates a migration and updates the database.
Accepts a "migration_name" parameter

### **roll-back-migration**
```bash
make roll-back-migration previous_migration={PREVIOUS_MIGRATION}
```

#### **Description**
Rollback migrations to a specific named migration.
Accepts a "previous" parameter

### **format**
```bash
make format
```

#### **Description**
Runs dotnet format which targets FVA.csproj and formats code.


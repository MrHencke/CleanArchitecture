# Clean Architecture in .NET Core 7

![Github top language](https://img.shields.io/github/languages/top/MrHencke/cleanarchitecture?color=56BEB8)
![Github language count](https://img.shields.io/github/languages/count/MrHencke/cleanarchitecture?color=56BEB8)
![Repository size](https://img.shields.io/github/repo-size/MrHencke/cleanarchitecture?color=56BEB8)
![Nuget Downloads](https://img.shields.io/nuget/dt/Hencke.Dev.CleanArchitecture?label=Downloads)
![License](https://img.shields.io/github/license/MrHencke/cleanarchitecture?color=56BEB8)

[About](about) &#xa0; | &#xa0; [Features](features) &#xa0; | &#xa0; [License](license) &#xa0; | &#xa0; [Author](https://github.com/MrHencke)

## About

This is my preferred template for a simple .NET Core 7 Web Api with Clean Architecture and CQRS.

If you have any use for it, feel free to drop a star.

## Features

- Database with EF Core + Postgres
- CQRS with MediatR
- Swagger with XMLDoc
- My preferred .editorconfig
- Example CRUD operations spanning entire project with a simple ExampleEntity


# Installation
To install run the following command

```
dotnet new install Hencke.Dev.CleanArchitecture
```

# Using
Either select the template from the visual studio template selection (Create a new project) or run the dotnet new command:
```
dotnet new h-cln -o YOURPROJECTNAME
```

# Running
When first running the created project, migrations must performed.
- Create an entry for "ConnectionStrings:DefaultConnection" in appsettings or UserSecrets in the api project.
- Run `dotnet ef migrations add "Initial Migration" --project YOURPROJECTNAME.Database --startup-project YOURPROJECTNAME.Api` to create a migration.
- - run `dotnet ef database update --project YOURPROJECTNAME.Database --startup-project YOURPROJECTNAME.Api` to persist the migration to your database
- Run the project with visual studio, targeting the api project or run `dotnet run src/YOURPROJECTNAME.Api` 

# Overview - Layers

## Abstractions
Abstractions contains all simple code objects like entities, enums and interfaces that are used in the domain, but does not originate from the database. These objects should be dependency free.
## Domain
Domain encapsulates all business logic and defines all entity handling and common behaviors. It also provides various services to the api layer.
## Database.Abstractions
Database.Abstractions contains all entities, interfaces pertaining to Db (like repository interfaces) and extensions that are only relevant to the Database layer.
## Database
Database contains the actual database context definition, repository implementations and DI for adding DbContext to the api layer.
## Api
The api layer exposes controllers and endpoints to allow CRUD actions on entities. All actions are sent with MediatR, which is common from the BaseController. The layer also defines the swagger configuration and request Dto objects.

&nbsp;

This project is made with :heart: by [Henrik](https://github.com/MrHencke)
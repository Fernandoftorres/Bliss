
## How to use:
- You will need the latest Visual Studio 2019 and the latest .NET Core SDK.
- ***Please check if you have installed the same runtime version (SDK) described in global.json***
- The latest SDK and tools can be downloaded from https://dot.net/core.

## Installation steps
- Change the appsettings.Development.json file in ./src/BlissRecruitment.Services.Api with the database data in the ConnectionString parameter.
"ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlissRecruitment;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
- Run the application

When running the application the tables will be created and data for testing will be inserted.

## Technologies implemented:

- ASP.NET Core 3.1 (with .NET Core 3.1)
 - ASP.NET MVC Core 
- Entity Framework Core 3.1
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- Domain Validations
- Event Sourcing
- Unit of Work
- Repository
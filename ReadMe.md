## Recipe App

A sample project for a recipe system

## Installation

- Project requires a SQL or SQLEXPRESS instance to be available. Connection string in appsettings.json should be adjusted accordingly.
- Please use Update-Database command on Package Manager Console to create the database.
- .Net Core 5.0 SDK must be installed.

## Libraries and Frameworks
- .Net Core 5.0
- EF Core 5.0
- Automapper 10.1.1 is utilized to map dto classes to entities and vice versa for user to consume the api.
- Swashbuckle.AspNetCore 5.6.3 to have auto generated documentation of the API
- Xunit 2.4.1 testing library.
- Microsoft.EntityFrameworkCore.InMemory 5.0.5 this is utilized for testing purposes on test layer.
- Moq 4.16.1 this one is installed but not utilized. it would be utilized for upcoming tests for their dependency injected services to be mocked.
## Usage

- Build the solution with Visual Studio or 'dotnet build' command with dotnet CLI.using 
- Run it using either Visual Studio or 'dotnet run' command with dotnet CLI in project's main directory.


## API

- The Api has 1 controller with 2 endpoints.
- [GET] Recipes : To fetch all existing recipes for view.
- [POST] Recipe : To save a recipe with all related data of it.


## Database Structure

There is a hierarchy of entities that are configured to make the system flexible to store any number of historical recipe with any number of properties that can be added.
The main idea is to store the data vertically rather than horizontally with pre-defined columns

Entities in this hierarchy is as following: 

- A Recipe can have any number of versions, this is to keep the historical data. 
Recipe - 1..n - Version 

- A Version can have any number of properties, medias and comments. 
Version - 1..n - Property
Version - 1..n - Media
Version - 1..n - Comment

- A Property could be any attribute of a recipe that keeps information.
The MetaItem of a property defines what is the "name and data type" that property keeps in its 'Value' field.

Property 1..1 MetaItem


## Testing Project
- Xunit is used as testing library along with it's runner.
- AAA pattern is utilized for testing convenstions
- Naming convension for tests is UnitOfWork_StateUnderTest_ExpectedBehavior
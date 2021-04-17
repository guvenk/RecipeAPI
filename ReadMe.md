## Recipe App

A sample project for a recipe system

## Installation

Project requires a SQL or SQLEXPRESS instance to be available. Connection string in appsettings.json should be adjusted accordingly.


## Usage

- Build the solution with Visual Studio or 'dotnet build' command with dotnet CLI.using 
- Run it using either Visual Studio or 'dotnet run' command with dotnet CLI in project's main directory.



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
# MarvelAPI

This project is an ASP.NET Core MVC Web API that allows you to explore Marvel Universe to provide information about characters, movies, planets, and series. It is built using .NET 8 and utilizes the Entity Framework Core for database interactions.

# Installation Instructions

To set up the Marvel API, install the appropriate versions of the necessary packages:
```
Install-Package Microsoft.EntityFrameworkCore -Version 8.0.10
Install-Package Pomelo.EntityFrameworkCore.MySql -Version 8.0.2
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.10
Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.10
```
These commands ensure that the API has the required dependencies for Entity Framework Core and MySQL integration.

After installing the necessary packages, run the following command to apply migrations and update the database schema:
```
Update-Database
```
This will apply migrations and ensure the database is up to date.

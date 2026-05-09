Overall site purpose and functionality.
-This ASP.NET Core MVC application is built to be utilized as an appointment scheduling tool for a dog grooming service.
The application allows the user to manage the Owners, Pets, Groomers, Appointments, and Services through the website.

Full CRUD operations on the 5 entities (Groomers/Owners/Pets/Appointments/Services)
Razor views for index/details/create/edit/delete.
dropdown menus between entities.

Key dependencies and setup instructions.

-Dependancies are; ASP.NET Core MVC (.NET 8), SQLLITE/SQL Server, Swagger, Bootstrap 5, Entity Framework Core.

-SETUP:Clone Repository, open in VS Code and resture NuGet packages, ensure appsettings.json configuration, then run the following migrations:
dotnet ef migrations add InitialCreate  ----&---- dotnet ef database update 
Open the application in browser and verify the site and swagger ui.


Design inspirations and feature descriptions.

My local groomer has no website setup, no scheduling or notes tool. She is working purely off of a calendar hanging in her grooming studio. This becomes an issue when she is not in the salon and I text her to schedule an appointment. If she utilized a database like this she could connect it to her google account calender and have all the appointments populate there. 



Key Features:
*Relational database structure utilizing Entity Framework Core. 
*Custom middleware logging time to process requests.
*Two reusable partial views for headers and navigation.
*Swagger integration.
*Smooth navigation between entities using Foreign Keys.
*Dropdown selection menus. 
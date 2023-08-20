# ASPNet-SidebarStarter

This is intended to be a starter project for a webapp that has a sidebar and a main content area. 
The sidebar is intended to be a menu to navigate around the application.
The main content area is intended to be a place where the user can interact with the application.

It is built using EF Core (LocalDB), ASP.NET Core, and Bootstrap 4.

# Setup and run
1. Install Visual Studio (Community Edition is OK!)
1. Install the ASP.NET and web development workload

## Steps to build 
1. Pull the code
1. Do a build		
1. In Visual Studio's Package Manager window, first validate that your default project is Starter.Model 
    - (NOTE: Package Manager Console is under Tools -> NuGet Package Manager -> Package Manager Console)

### To use the predefined DB (ASPNetStarter)
1. Run the command:

```
PM> Update-Database -Context DBContext
```

### To create a new DB with a different name
1. Delete the Migrations folder					
1. Update appsettings.json to have a different name for the DB
1. Initialize the DB with the commands:
  	- The first will recreate the Migrations folder
    - The second will create the DB and structure
 
```
PM> Add-Migration InitialCreate
PM> Update-Database -Context DBContext
```

## Steps to run
1. Click the green play button in visual studio
1. (On first run) Agree to trust the self-signed certificate
    - Note: Also on the first run the DB will be seeded with fake users (DBInitializer, called in Program.cs)

## Steps to debug
1. Place a breakpoint in the code, it will be automatically caught when running the application

# Database

## Connect via Visual Studio to query data
1. Open Server Explorer (View -> Server Explorer)
1. Connect to a data source - Microsoft SQL server with a server name of `(localdb)\MSSQLLocalDB` using Windows Authentication, choosing ASPNetStarter as the database
1. Right click the database to create a new query

## Create a new migration
In Visual Studio's Package Manager window, first validate that your default project is Starter.Model, then run the command:

```
PM> Add-Migration M0001_<YourMigrationName> -Context DBContext
```

## Update the database
Once your migration is complete, run the command

```
PM> Update-Database -Context DBContext
```

## Revert a migration
```
PM> Update-Database -Context <PreviousMigrationName>
```

## Remove a migration
```
PM > Remove-Migration -Context DBContext
```

### If you need to reset the DB you'll need to reseed the identity columns
```
--delete from Users
--DBCC CHECKIDENT ('Users', RESEED, 0);
```


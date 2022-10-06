:: To delete an existing database 
dotnet ef database update 0 --context UniversityDbContext 

:: To remove existing migrations 
dotnet ef migrations remove --context UniversityDbContext 

:: To create a new EF migration, with name InitialCreate
dotnet ef migrations add InitialCreate --context UniversityDbContext

:: To apply migrations to the database
:: All tables specified in UniversityDbContext would be created in the database
dotnet ef database update --context UniversityDbContext
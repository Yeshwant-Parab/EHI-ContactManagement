# EHI-ContactManagement

*Application for maintaining contact information.*

## Functionality:
- List contacts
- Add a contact
- Edit contact
- Delete/Inactivate a contact

## Project Structure:
1. ###### EHI.UserManagement.Repository
	- Configuration folder: Contains database configuration for Entities.
	- Context folder: Contains database context class.
	- Entities foldee: Contains application Entities.
	- Enums folder: Contains Enums.
	- Interface folder: Contains Interfaces for defining Database operations on Entities.
	- Repositories folder: Contains implentation of Interfaces for Database operations on Entities.
	- DbInitializer.cs: Creates a new database/table(If not exist) and seeds some data.
	- MappingProfiles.cs: Maps Entities to DTO objects.
	
2. ###### EHI.UserManagement.Business
	- Controllers folder: Contains Api controller classes to expose REST API's.
  
3. ###### EHI.UserManagement.Dto
	- Contact folder: Contains DTO classes used transfer data from web api to web project.
  
4. ###### EHI.UserManagement.Web
	- Controllers folder: MVC for consuming API's and displaying Views.
	- Views folder: Contains Views.

## Run the Application:
###### IDE used: Visual Studio 2019
Replace the connection string in ***appsettings.json*** in ***EHI.UserManagement.Business*** project, the application is configured to use SQL server database, in-case of any other Database please update the Entity Framework provider.
``` 
"ConnectionStrings": {
    "DefaultConnection": "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True"
  }
  ```

The application has been configured  to run both ***EHI.UserManagement.Business*** and ***EHI.UserManagement.Web*** as startup projects.
***EHI.UserManagement.Business*** is configured to run on ***http://localhost:51205/***, in-case it runs on any other port please update ***DefaultUrl*** in appsettings.json*** of ***EHI.UserManagement.Web project***.
``` 
"ApiUrl": {
    "DefaultUrl": "http://localhost:51205/"

  }
  ```
  Once the above configurations are done, Build and Run the application.


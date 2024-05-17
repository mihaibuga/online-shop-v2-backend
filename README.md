# Online Shop V2 Backend

## Initialize the project

- Install [Microsoft SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
- Create a new database

- Get the Connection String
    - Open solution in **Visual Studio**
    - In **Visual Studio**'s main tab, Select the **View** tab -> **SQL Server Object Explorer**
    - Find the database you've created and expand it
    - Right click on it's name and select Properties
    - In the Properties window, search for the **Connection string** property
    - Copy the string value in that property

        (__Example__: *Data Source=<computer-name>\SQLEXPRESS;Initial Catalog=onlineShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False*)

- Open the **appsettings.json** file
- Copy the lines with **ConnectionStrigns** and **JWT**
```
  "ConnectionStrings": {
    "DefaultConnection": ""
  },
  "JWT": {
    "Issuer": "http://localhost:5246",
    "Audience": "http://localhost:5246",
    "SigningKey": ""
  }
```
- Right click on the **OnlineShop.API** and select **Manage User Secrets**
- Paste there the lines you've copied
- Add the **Connection string** in the **DefaultConnection** property

    __Example__

        ...
        "DefaultConnection": "Data Source=<computer-name>\SQLEXPRESS;Initial Catalog=onlineShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
        ...
- Add the long enough string in the **JWT SigningKey** property

    __Example__

        ...
        "SigningKey": "askjasdhkjskjasfkhjfdhkjdfdhknmeheejlkasdnkasdnkalsnalsknalsfknaslknalskdnnsns"
        ...

## Create Initial Migration

In Visual Studio main tab, Select Tools -> NuGet Package Manager -> Package Manager Console

Run the following commands:
- Add-Migration InitialMigration -Context ApplicationDbContext
- update-database -Context ApplicationDbContext


- Add-Migration InitialMigration -Context IdentityDbContext
- update-database -Context IdentityDbContext

## Remove the last migration
Run the following command:
- remove-migration -Context ApplicationDbContext

or

- remove-migration -Context IdentityDbContext

## Run the project
- Open the terminal and navigate to the OnlineShop.API folder
- While in the OnlineShop.API folder, run the following command:
    - dotnet watch run

## Swagger UI
- The Swagger UI will open in the browser
- You can now register your first account
- Login with the credentials you've used to register
- Copy the "token" value from the response body after you've logged in
- Go to the top of the Swagger page and click on the Authorize button
- Enter on the Value text input field the token value you've copied and press Authorize
- You can now start using all application's features

##

Thanks for the visit!
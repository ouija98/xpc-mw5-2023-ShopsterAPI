# ShopsterAPI

This project is the variant A of the xpc-mw5-2023 project assignment.

ShopsterAPI is a RESTful API built using ASP.NET Core that provides functionality for managing commodities, manufacturers, ratings, and categories.

## Installation

To run the project locally, you will need to have .NET Core installed on your machine. You can download .NET Core from [here](https://dotnet.microsoft.com/download).

1. Clone the repository to your local machine.
2. Edit your appsettings.json connection string to database.
3. Open a terminal or command prompt in the project directory and run the following command to install the required dependencies: `dotnet build`
4. Enter directory of Shopster.API and run the following command to create and migrate the database: `dotnet ef database update`
5. Finally, run the following command to start the application: `dotnet run`
## Endpoints

- `/api/commodities`: Provides CRUD operations for commodities.
- `/api/manufacturers`: Provides CRUD operations for manufacturers.
- `/api/ratings`: Provides CRUD operations for ratings.
- `/api/categories`: Provides CRUD operations for categories.

- `api/commodities/search`: Allows searching for commodities based on specific criteria such as name, price range, category, and minimum rating.
- `/api/ratings/{commodityId}/rating`: Retrieves the ratings associated with a specific commodity identified by the {`commodityId`} parameter.

## Creators

- Bartkova Tereza
- Szüč Martin
- Bartash Roman


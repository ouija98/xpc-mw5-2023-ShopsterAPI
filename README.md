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

* `/api/commodity`: Provides CRUD operations for commodities.
  * `/commodity/top-rated`: Retrieves the top-rated commodities based on the average rating. 
  * `/commodity/search`:
    * Parameters:
      * `name`: (string, optional) Filter commodities by name.
      * `minPrice`: (decimal, optional) Filter commodities with a minimum price.
      *  `maxPrice`: (decimal, optional) Filter commodities with a maximum price.
      *  `categoryId`: (GUID, optional) Filter commodities by category ID.
      *  `minRating`: (integer, optional) Filter commodities with a minimum rating.
      *  `manufacturerFilter`: (string, optional) Filter commodities by manufacturer name or ID.
        *  `sort`: (string, optional) Sort `attribute:order`. Available attributes: `name`, `price`, `rating`. Available order: `asc` (ascending), `desc` (descending). 
      Format: `attribute:order`. Available attributes: `name`, `price`, `rating`. Available order: `asc` (ascending), `desc` (descending).
     
* `/api/manufacturer`: Provides CRUD operations for manufacturers.
* `/api/rating`: Provides CRUD operations for ratings.
    * `/rating/{commodityId}/rating`: Retrieves the ratings associated with a specific commodity identified by the {`commodityId`} parameter.
* `/api/category`: Provides CRUD operations for categories.


## Creators

- Bartkova Tereza
- Szüč Martin
- Bartash Roman


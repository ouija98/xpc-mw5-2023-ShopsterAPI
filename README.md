<!DOCTYPE html>
<html>
<head>
    <title>ShopsterAPI - README</title>
</head>
<body>
    <h1>ShopsterAPI</h1>
    <p>This project is the variant A of the xpc-mw5-2023 project assignment.</p>
    <p>ShopsterAPI is a RESTful API built using ASP.NET Core that provides functionality for managing commodities, manufacturers, ratings, and categories.</p>

    <h2>Installation</h2>
    <p>To run the project locally, you will need to have .NET Core installed on your machine. You can download .NET Core from <a href="https://dotnet.microsoft.com/download">here</a>.</p>

    <ol>
        <li>Clone the repository to your local machine.</li>
        <li>Open a terminal or command prompt in the project directory and run the following command to install the required dependencies:</li>
        <pre>dotnet restore</pre>
        <li>Run the following command to create and migrate the database:</li>
        <pre>dotnet ef database update</pre>
        <li>Finally, run the following command to start the application:</li>
        <pre>dotnet run</pre>
    </ol>

    <h2>Endpoints</h2>
    <ul>
        <li><strong>/api/commodities</strong>: Provides CRUD operations for commodities.</li>
        <li><strong>/api/manufacturers</strong>: Provides CRUD operations for manufacturers.</li>
        <li><strong>/api/ratings</strong>: Provides CRUD operations for ratings.</li>
        <li><strong>/api/categories</strong>: Provides CRUD operations for categories.</li>
    </ul>

    <h2>Creators</h2>
    <ul>
        <li>Bartkova Tereza</li>
        <li>Szüč Martin</li>
        <li>Bartash Roman</li>
    </ul>

</body>
</html>

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopster.Migrations
{
    /// <inheritdoc />
    public partial class CommoditiesTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("5546c821-91c9-4028-87f0-8cb91f74332b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("5a6fd43a-e5a2-41cf-bd46-88dc541640bc"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("636d3b34-27a0-4b48-97a3-647a1d2b96de"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe4da7c0-f5ae-4537-a770-b39374483b9b"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("117af01b-ee1c-4a9c-87e5-9297368e95fb"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("1fa987c0-bfb5-4d1f-b7cd-cb114cec59b8"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("22955e6d-82a9-498a-a00a-f90a5a9148df"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("82ea037c-128e-4583-953e-4e13466b6dd9"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("ec0e37f6-707d-4719-9cd7-0f86aed9f9db"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fbe43847-0ee3-4684-89e8-cdcfac9763bd"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("204d7eab-ef30-4226-a231-ef29626e0770"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7397a2ce-af81-4d4b-84c1-2e37984e5df2"), "ctg1" },
                    { new Guid("9bba9fc0-674a-449a-8d98-349555819fa0"), "ctg3" },
                    { new Guid("b1d2ee9b-cdfa-4d9a-9d29-49d52123b02e"), "ctg5" },
                    { new Guid("c7daa61e-4cb9-4e1f-a02f-1ad327200a47"), "ctg6" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CountryOfOrigin", "Description", "Logo", "Name" },
                values: new object[,]
                {
                    { new Guid("11d26544-a730-427a-8b30-ba7d154d31ae"), "CZ", "desc3", "logo3.png", "manu3" },
                    { new Guid("81363ec8-2b79-46f8-95ca-e47790135731"), "CZ", "desc2", "logo2.png", "manu2" },
                    { new Guid("ec2e0405-2227-4510-89e3-8dcb6c7e76b6"), "CZ", "desc1", "logo1.png", "manu1" },
                    { new Guid("fc12bd43-cb22-42ce-a0e8-f5d98267be06"), "CZ", "desc4", "logo4.png", "manu4" }
                });

            migrationBuilder.InsertData(
                table: "Commodity",
                columns: new[] { "Id", "CategoryId", "Description", "ManufacturerId", "Name", "Picture", "Price", "Quantity", "Weight" },
                values: new object[,]
                {
                    { new Guid("26e1b935-9c8d-4d74-9957-96d96020b74f"), new Guid("c7daa61e-4cb9-4e1f-a02f-1ad327200a47"), "desc3", new Guid("11d26544-a730-427a-8b30-ba7d154d31ae"), "cmd3", "picture.jpg", 23254m, 20, 15f },
                    { new Guid("4e170f02-35e2-445a-96ce-fd4e65b35d4b"), new Guid("7397a2ce-af81-4d4b-84c1-2e37984e5df2"), "desc1", new Guid("11d26544-a730-427a-8b30-ba7d154d31ae"), "cmd1", "picture.jpg", 10m, 2, 20f },
                    { new Guid("84b2d548-8371-4cdb-9d69-abd0e8dbd3d7"), new Guid("c7daa61e-4cb9-4e1f-a02f-1ad327200a47"), "desc4", new Guid("fc12bd43-cb22-42ce-a0e8-f5d98267be06"), "cmd4", "picture.jpg", 55m, 10, 15f },
                    { new Guid("f31e115b-3e23-47a3-824d-68c0c5490af8"), new Guid("9bba9fc0-674a-449a-8d98-349555819fa0"), "desc2", new Guid("81363ec8-2b79-46f8-95ca-e47790135731"), "cmd2", "picture.jpg", 1m, 2, 5f }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "CommodityEntityId", "Description", "Stars", "Title" },
                values: new object[] { new Guid("93bea869-8421-48c2-bcea-474b0a91a7af"), new Guid("4e170f02-35e2-445a-96ce-fd4e65b35d4b"), "desc1", 1, "title1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b1d2ee9b-cdfa-4d9a-9d29-49d52123b02e"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("26e1b935-9c8d-4d74-9957-96d96020b74f"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("84b2d548-8371-4cdb-9d69-abd0e8dbd3d7"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("f31e115b-3e23-47a3-824d-68c0c5490af8"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("ec2e0405-2227-4510-89e3-8dcb6c7e76b6"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("93bea869-8421-48c2-bcea-474b0a91a7af"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9bba9fc0-674a-449a-8d98-349555819fa0"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c7daa61e-4cb9-4e1f-a02f-1ad327200a47"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("4e170f02-35e2-445a-96ce-fd4e65b35d4b"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("81363ec8-2b79-46f8-95ca-e47790135731"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("fc12bd43-cb22-42ce-a0e8-f5d98267be06"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("7397a2ce-af81-4d4b-84c1-2e37984e5df2"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("11d26544-a730-427a-8b30-ba7d154d31ae"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5546c821-91c9-4028-87f0-8cb91f74332b"), "ctg22" },
                    { new Guid("5a6fd43a-e5a2-41cf-bd46-88dc541640bc"), "ctg3" },
                    { new Guid("636d3b34-27a0-4b48-97a3-647a1d2b96de"), "ctg5" },
                    { new Guid("fbe43847-0ee3-4684-89e8-cdcfac9763bd"), "ctg1" },
                    { new Guid("fe4da7c0-f5ae-4537-a770-b39374483b9b"), "ctg6" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CountryOfOrigin", "Description", "Logo", "Name" },
                values: new object[,]
                {
                    { new Guid("117af01b-ee1c-4a9c-87e5-9297368e95fb"), "CZ", "desc3", "logo3.png", "manu3" },
                    { new Guid("1fa987c0-bfb5-4d1f-b7cd-cb114cec59b8"), "CZ", "desc1", "logo1.png", "manu1" },
                    { new Guid("204d7eab-ef30-4226-a231-ef29626e0770"), "CZ", "desc2", "logo2.png", "manu2" },
                    { new Guid("22955e6d-82a9-498a-a00a-f90a5a9148df"), "CZ", "desc4", "logo4.png", "manu4" }
                });

            migrationBuilder.InsertData(
                table: "Commodity",
                columns: new[] { "Id", "CategoryId", "Description", "ManufacturerId", "Name", "Picture", "Price", "Quantity", "Weight" },
                values: new object[] { new Guid("ec0e37f6-707d-4719-9cd7-0f86aed9f9db"), new Guid("fbe43847-0ee3-4684-89e8-cdcfac9763bd"), "desc1", new Guid("204d7eab-ef30-4226-a231-ef29626e0770"), "cmd1", "picture.jpg", 10m, 2, 15f });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "CommodityEntityId", "Description", "Stars", "Title" },
                values: new object[] { new Guid("82ea037c-128e-4583-953e-4e13466b6dd9"), new Guid("ec0e37f6-707d-4719-9cd7-0f86aed9f9db"), "desc1", 1, "title1" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopster.Migrations
{
    /// <inheritdoc />
    public partial class RatingTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("0d304865-047b-4f98-b47b-c6a9aa8d8f0e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3fb6a786-495b-4aba-bb9d-467847ca42d2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b5df0ce7-b292-4121-bce7-871edfaa6b13"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d1aa8d00-16af-4881-a036-5aafdb687c7b"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("190394f2-1be2-44c7-b695-a60c7c02c400"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("04007188-becf-4518-8d39-7ff1a3ba53ef"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("0b18e709-ad57-4c89-8dda-3e40b928466b"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("ba797672-2462-4679-8852-ac56b5150800"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9106fe7b-0386-4269-b3d1-7ff1c5c730b3"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("c997e832-179a-4d3e-a300-26482ede98b8"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("0d304865-047b-4f98-b47b-c6a9aa8d8f0e"), "ctg5" },
                    { new Guid("3fb6a786-495b-4aba-bb9d-467847ca42d2"), "ctg6" },
                    { new Guid("9106fe7b-0386-4269-b3d1-7ff1c5c730b3"), "ctg1" },
                    { new Guid("b5df0ce7-b292-4121-bce7-871edfaa6b13"), "ctg3" },
                    { new Guid("d1aa8d00-16af-4881-a036-5aafdb687c7b"), "ctg22" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CountryOfOrigin", "Description", "Logo", "Name" },
                values: new object[,]
                {
                    { new Guid("04007188-becf-4518-8d39-7ff1a3ba53ef"), "CZ", "desc1", "logo1.png", "manu1" },
                    { new Guid("0b18e709-ad57-4c89-8dda-3e40b928466b"), "CZ", "desc4", "logo4.png", "manu4" },
                    { new Guid("ba797672-2462-4679-8852-ac56b5150800"), "CZ", "desc3", "logo3.png", "manu3" },
                    { new Guid("c997e832-179a-4d3e-a300-26482ede98b8"), "CZ", "desc2", "logo2.png", "manu2" }
                });

            migrationBuilder.InsertData(
                table: "Commodity",
                columns: new[] { "Id", "CategoryId", "Description", "ManufacturerId", "Name", "Picture", "Price", "Quantity", "Weight" },
                values: new object[] { new Guid("190394f2-1be2-44c7-b695-a60c7c02c400"), new Guid("9106fe7b-0386-4269-b3d1-7ff1c5c730b3"), "desc1", new Guid("c997e832-179a-4d3e-a300-26482ede98b8"), "ctg1", "picture.jpg", 10m, 2, 15f });
        }
    }
}

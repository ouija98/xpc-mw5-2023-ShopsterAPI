using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopster.Migrations
{
    /// <inheritdoc />
    public partial class CommodityTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("015d5097-3101-40f8-9ebb-8035e7dff5e2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("01739358-e8d4-4f00-b23e-c90340c3e37a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("112db897-e25d-48e4-a7c3-c36517c3e721"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("937bbcab-ae1a-47e8-9d2c-13d2177e1943"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b20de7a8-d245-4403-a045-88a966f4d7f2"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("1d9daaeb-d8c9-4099-9a1a-0e847ca5b0f6"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("4025afe3-b4d2-408b-9b41-a46896a66ddc"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("aaf01d3c-d467-48c7-8ffd-7ead4bb0886d"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("e27faded-657a-42e1-9de7-2dce3ab38db4"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("015d5097-3101-40f8-9ebb-8035e7dff5e2"), "ctg5" },
                    { new Guid("01739358-e8d4-4f00-b23e-c90340c3e37a"), "ctg3" },
                    { new Guid("112db897-e25d-48e4-a7c3-c36517c3e721"), "ctg22" },
                    { new Guid("937bbcab-ae1a-47e8-9d2c-13d2177e1943"), "ctg1" },
                    { new Guid("b20de7a8-d245-4403-a045-88a966f4d7f2"), "ctg6" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CountryOfOrigin", "Description", "Logo", "Name" },
                values: new object[,]
                {
                    { new Guid("1d9daaeb-d8c9-4099-9a1a-0e847ca5b0f6"), "CZ", "desc3", "logo3.png", "manu3" },
                    { new Guid("4025afe3-b4d2-408b-9b41-a46896a66ddc"), "CZ", "desc4", "logo4.png", "manu4" },
                    { new Guid("aaf01d3c-d467-48c7-8ffd-7ead4bb0886d"), "CZ", "desc2", "logo2.png", "manu2" },
                    { new Guid("e27faded-657a-42e1-9de7-2dce3ab38db4"), "CZ", "desc1", "logo1.png", "manu1" }
                });
        }
    }
}

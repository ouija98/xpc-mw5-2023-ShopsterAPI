using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopster.Migrations
{
    /// <inheritdoc />
    public partial class RatingsTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("09efdfd4-4e51-4c66-bf72-b80cc71de970"), "ctg6" },
                    { new Guid("1013de7d-c130-4440-ac15-e0e224f9aefc"), "ctg1" },
                    { new Guid("5cf1cc47-04ac-48f8-b43c-5bc96a40ac8e"), "ctg3" },
                    { new Guid("7b961675-8b26-4866-af16-7a3eaffd7949"), "ctg5" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CountryOfOrigin", "Description", "Logo", "Name" },
                values: new object[,]
                {
                    { new Guid("334a87ef-d557-49cc-9c65-d6db05dd7425"), "CZ", "desc3", "logo3.png", "manu3" },
                    { new Guid("759a91d0-afc6-422d-a388-c8b517935667"), "CZ", "desc1", "logo1.png", "manu1" },
                    { new Guid("94cd9937-55d7-4dac-8ec5-235efbd905dd"), "CZ", "desc4", "logo4.png", "manu4" },
                    { new Guid("ae9d1446-b6b5-4ad5-a983-e37eac15370f"), "CZ", "desc2", "logo2.png", "manu2" }
                });

            migrationBuilder.InsertData(
                table: "Commodity",
                columns: new[] { "Id", "CategoryId", "Description", "ManufacturerId", "Name", "Picture", "Price", "Quantity", "Weight" },
                values: new object[,]
                {
                    { new Guid("0c9cb969-ad41-4be3-a7ca-a65ac3371508"), new Guid("1013de7d-c130-4440-ac15-e0e224f9aefc"), "desc1", new Guid("334a87ef-d557-49cc-9c65-d6db05dd7425"), "cmd1", "picture.jpg", 10m, 2, 20f },
                    { new Guid("6d46d6d6-7620-4912-9a19-57bf1a672aa9"), new Guid("5cf1cc47-04ac-48f8-b43c-5bc96a40ac8e"), "desc2", new Guid("ae9d1446-b6b5-4ad5-a983-e37eac15370f"), "cmd2", "picture.jpg", 1m, 2, 5f },
                    { new Guid("b65682de-f311-44d4-bd55-e2ea99cc5fbc"), new Guid("09efdfd4-4e51-4c66-bf72-b80cc71de970"), "desc3", new Guid("334a87ef-d557-49cc-9c65-d6db05dd7425"), "cmd3", "picture.jpg", 23254m, 20, 15f },
                    { new Guid("fff73b1a-34f5-4539-a004-d2cdd5a55994"), new Guid("09efdfd4-4e51-4c66-bf72-b80cc71de970"), "desc4", new Guid("94cd9937-55d7-4dac-8ec5-235efbd905dd"), "cmd4", "picture.jpg", 55m, 10, 15f }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "CommodityEntityId", "Description", "Stars", "Title" },
                values: new object[,]
                {
                    { new Guid("2ad975f5-a92c-4ba6-b26c-23e141de1774"), new Guid("fff73b1a-34f5-4539-a004-d2cdd5a55994"), "desc3", 5, "title3" },
                    { new Guid("53da0d9c-569e-4ad1-a2b7-7570886ea1ca"), new Guid("0c9cb969-ad41-4be3-a7ca-a65ac3371508"), "desc4", 4, "title4" },
                    { new Guid("9056e54a-180c-4c13-a637-8245d5f368fd"), new Guid("6d46d6d6-7620-4912-9a19-57bf1a672aa9"), "desc1", 1, "title1" },
                    { new Guid("a4b57112-adeb-4645-9d19-d65b5218fbc2"), new Guid("6d46d6d6-7620-4912-9a19-57bf1a672aa9"), "desc2", 5, "title2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("7b961675-8b26-4866-af16-7a3eaffd7949"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("b65682de-f311-44d4-bd55-e2ea99cc5fbc"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("759a91d0-afc6-422d-a388-c8b517935667"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("2ad975f5-a92c-4ba6-b26c-23e141de1774"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("53da0d9c-569e-4ad1-a2b7-7570886ea1ca"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("9056e54a-180c-4c13-a637-8245d5f368fd"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("a4b57112-adeb-4645-9d19-d65b5218fbc2"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("0c9cb969-ad41-4be3-a7ca-a65ac3371508"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("6d46d6d6-7620-4912-9a19-57bf1a672aa9"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("fff73b1a-34f5-4539-a004-d2cdd5a55994"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("09efdfd4-4e51-4c66-bf72-b80cc71de970"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1013de7d-c130-4440-ac15-e0e224f9aefc"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("5cf1cc47-04ac-48f8-b43c-5bc96a40ac8e"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("334a87ef-d557-49cc-9c65-d6db05dd7425"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("94cd9937-55d7-4dac-8ec5-235efbd905dd"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("ae9d1446-b6b5-4ad5-a983-e37eac15370f"));

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
    }
}

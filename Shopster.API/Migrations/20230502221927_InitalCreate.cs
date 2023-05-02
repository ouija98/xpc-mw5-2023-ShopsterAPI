using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopster.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commodity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commodity_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commodity_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommodityEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Commodity_CommodityEntityId",
                        column: x => x.CommodityEntityId,
                        principalTable: "Commodity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("66259208-4099-1b19-44f3-00fe98396ef0"), "Industrial & Games" },
                    { new Guid("e6ca87d1-ad83-a11b-3725-205c718a331d"), "Beauty & Industrial" },
                    { new Guid("f535824d-88df-32d0-26a3-7af1f61f848c"), "Home, Industrial & Music" },
                    { new Guid("f6e8dfdd-11a8-38ec-bdf7-962164980a72"), "Shoes, Clothing & Music" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CountryOfOrigin", "Description", "Logo", "Name" },
                values: new object[,]
                {
                    { new Guid("29dbf0d1-eb15-0517-30c6-f9bfe9a809f7"), "Finland", "Quia expedita et aut facilis qui. Ut aperiam similique aut optio beatae necessitatibus sed suscipit. Voluptates eveniet voluptatem voluptate quisquam nam quas veniam reprehenderit. Omnis magni blanditiis libero et ipsam sed maiores aut. Natus eaque perspiciatis eum quae dolorem. Id dignissimos voluptatum dolores ea voluptatem nobis.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/981.jpg", "Runte - Hayes" },
                    { new Guid("9cb0d800-7504-f20e-719e-416d644847db"), "Russian Federation", "Voluptatum quibusdam sapiente provident porro tenetur perferendis quis perspiciatis. Architecto eum corrupti voluptas omnis odit sed. Ipsam accusantium est distinctio nam voluptatem debitis et.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/288.jpg", "Lesch Group" },
                    { new Guid("b7afcea0-dc5b-bfa6-e585-b468e58410b1"), "Saint Barthelemy", "Odit rerum ad illo illum qui. Enim laborum voluptate minus nihil voluptas quia facere architecto aut. Corporis perferendis culpa consectetur aut accusamus. Consequatur labore numquam reprehenderit. Excepturi vitae non vero inventore soluta corporis consectetur. Labore consectetur sit reprehenderit itaque sit aut ut eveniet.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/564.jpg", "Kulas - Gutkowski" },
                    { new Guid("f2a27d99-8874-f369-0f29-0a73a0e38d2e"), "Peru", "Quis voluptatum animi omnis sit ut nesciunt. Dolor officia qui nostrum veniam voluptate. Expedita vel commodi explicabo sapiente molestiae. Ipsum ut temporibus. Recusandae sit maxime consequuntur dolores et facilis et.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1127.jpg", "Mueller, Gleichner and Gutkowski" }
                });

            migrationBuilder.InsertData(
                table: "Commodity",
                columns: new[] { "Id", "CategoryId", "Description", "ManufacturerId", "Name", "Picture", "Price", "Quantity", "Weight" },
                values: new object[,]
                {
                    { new Guid("43943901-7b1b-935d-d3f6-19ead6e22423"), new Guid("66259208-4099-1b19-44f3-00fe98396ef0"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new Guid("b7afcea0-dc5b-bfa6-e585-b468e58410b1"), "Small Metal Gloves", "https://picsum.photos/640/480/?image=271", 154.72695226683007m, 60, 17.495409f },
                    { new Guid("6659f0ce-e1da-2152-be17-04840fb37d46"), new Guid("66259208-4099-1b19-44f3-00fe98396ef0"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new Guid("b7afcea0-dc5b-bfa6-e585-b468e58410b1"), "Generic Plastic Gloves", "https://picsum.photos/640/480/?image=968", 187.411800010754836m, 56, 9.5668955f },
                    { new Guid("c43d6fc5-c41b-56c1-5735-97515debc14a"), new Guid("66259208-4099-1b19-44f3-00fe98396ef0"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new Guid("b7afcea0-dc5b-bfa6-e585-b468e58410b1"), "Gorgeous Cotton Ball", "https://picsum.photos/640/480/?image=635", 737.466697071283744m, 5, 95.58386f },
                    { new Guid("f2067f69-9181-4edb-8b36-4346c7906a6a"), new Guid("f535824d-88df-32d0-26a3-7af1f61f848c"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new Guid("f2a27d99-8874-f369-0f29-0a73a0e38d2e"), "Licensed Steel Salad", "https://picsum.photos/640/480/?image=53", 69.1803058136518801m, 21, 31.15961f }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "CommodityEntityId", "Description", "Stars", "Title" },
                values: new object[,]
                {
                    { new Guid("295333c8-d328-f22b-6f88-1c4ad578f52c"), new Guid("f2067f69-9181-4edb-8b36-4346c7906a6a"), "Ab tempore iure exercitationem. Culpa sit consequatur aut. Asperiores dignissimos repellat ut accusamus quis quam et nobis consequatur. Animi praesentium nemo unde cupiditate harum eveniet optio. Odit quasi voluptas expedita ea sint numquam. Similique voluptatem molestiae ea et tempora dolores.", 3, "Quos veniam esse est cum inventore." },
                    { new Guid("4ff3ef5a-a11e-5779-dec9-bf61a8dbc6d0"), new Guid("43943901-7b1b-935d-d3f6-19ead6e22423"), "Quia quo libero aut omnis. Sed aut non dolor provident autem. Cum nihil voluptatem id dolore. Est quia harum qui assumenda ab at. Incidunt id adipisci nihil reiciendis eveniet dolores qui eum.", 3, "Velit possimus in ad pariatur ipsa et est." },
                    { new Guid("973d3853-a453-d64c-8025-eda34b8b201b"), new Guid("6659f0ce-e1da-2152-be17-04840fb37d46"), "Quia ut velit incidunt et. Est iure occaecati. Vero quibusdam assumenda doloribus et unde ea qui nobis.", 4, "Laborum eius fugit asperiores ut unde est." },
                    { new Guid("aa1546ee-393c-4a56-2d8c-b5e4d8d2fa2f"), new Guid("43943901-7b1b-935d-d3f6-19ead6e22423"), "Et soluta dolores dolorum voluptatem harum ea esse cupiditate. Distinctio dicta est. Autem magni cum tempora fuga.", 3, "Perspiciatis cumque vero itaque eos et eveniet vel dolores sunt." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_CategoryId",
                table: "Commodity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_ManufacturerId",
                table: "Commodity",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_CommodityEntityId",
                table: "Rating",
                column: "CommodityEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Commodity");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}

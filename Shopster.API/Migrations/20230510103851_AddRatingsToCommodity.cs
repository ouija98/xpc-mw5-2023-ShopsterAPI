using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopster.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingsToCommodity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("df69efcb-cb62-5881-4a8b-9b242c215ba4"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("aee56139-bc98-d9d5-2aa5-ebb90c4f87aa"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("3f699363-a183-b058-07fb-bc5cc9012d6e"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("f39c7659-6e31-8946-de32-1d0f1c777039"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("672dd54a-d42c-18ab-a4fd-e07a1cfd0863"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("86493e3a-9441-93ab-f2d6-52242a9c4f59"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("92ec72f7-0616-730f-efed-14a93003e115"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("de7a8bf9-0345-b1b9-dd98-f642cc19e350"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("064031c2-dfcf-0dfa-c2cf-736a82190788"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("06afb9db-f6a4-ac23-6430-e0e23b66282d"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("ae2d39c9-3a05-617c-c0fc-82c43fd6302f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("166e5d30-2f53-fe75-979a-7a9394d3ee8a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("44400198-729b-ca78-7765-22a8e8c9e9e8"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("7f13c2b3-9ac5-d41a-7963-9eff0dee57c9"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("0f6b20b2-3679-486b-ed43-76c50f9f2100"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("a4b2b288-760f-ccb4-668b-2b030f569781"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4954fefa-151e-9441-e45d-c05e846e229d"), "Kids & Beauty" },
                    { new Guid("647684b3-76c5-0519-1e33-43ad3be2ba79"), "Baby, Baby & Music" },
                    { new Guid("f07d68e8-f5ff-3f1f-9374-d671b54809ab"), "Music" },
                    { new Guid("f9d93c6d-09e8-f103-2279-2d08eeb69171"), "Outdoors & Grocery" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CountryOfOrigin", "Description", "Logo", "Name" },
                values: new object[,]
                {
                    { new Guid("8ead666e-5589-3921-763e-c9a379b0e549"), "China", "Illum animi est est nesciunt qui vitae iusto non enim. Delectus recusandae modi officia debitis labore iure facere. Molestiae quo laboriosam asperiores suscipit quaerat quam ratione. Voluptas ad est eveniet qui rerum reprehenderit voluptatem. Illum nemo eius sit quae earum porro. Assumenda est dolores eos laboriosam voluptatibus est est aut minus.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/341.jpg", "Langworth - Lebsack" },
                    { new Guid("8f457a31-5463-05c0-29ae-2e46003ded60"), "Estonia", "Quidem qui tempora voluptatum suscipit. Quia et corrupti numquam qui mollitia cupiditate cumque et autem. Possimus aut placeat dolore rem eum et reiciendis voluptatem.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/814.jpg", "Buckridge, Robel and Bashirian" },
                    { new Guid("bfb8062a-4445-df04-4016-8cb172475b5c"), "Switzerland", "Repudiandae aut aliquid qui. Consequatur ut deleniti incidunt soluta. Autem nulla nihil. Iure laborum aperiam. Voluptatem esse dolorem autem ut qui sint sed. Et esse dicta consequuntur et exercitationem architecto voluptas occaecati est.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/70.jpg", "Zieme - Lebsack" },
                    { new Guid("e50df1e0-76e8-54a9-a4ca-625c08963f21"), "Somalia", "Velit velit aut. Nesciunt cupiditate officia ducimus aut cum. Et voluptatem eveniet quaerat qui occaecati quos et quos. Saepe debitis consequuntur iure.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/826.jpg", "Murray Inc" }
                });

            migrationBuilder.InsertData(
                table: "Commodity",
                columns: new[] { "Id", "CategoryId", "Description", "ManufacturerId", "Name", "Picture", "Price", "Quantity", "Weight" },
                values: new object[,]
                {
                    { new Guid("4d02891e-8511-25da-72c9-d9c78a5f05bb"), new Guid("4954fefa-151e-9441-e45d-c05e846e229d"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new Guid("8f457a31-5463-05c0-29ae-2e46003ded60"), "Fantastic Concrete Chair", "https://picsum.photos/640/480/?image=153", 991.495184142350836m, 2, 35.32461f },
                    { new Guid("56847a0f-bfd5-8138-98a5-26a16c169187"), new Guid("f07d68e8-f5ff-3f1f-9374-d671b54809ab"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new Guid("8f457a31-5463-05c0-29ae-2e46003ded60"), "Handmade Rubber Computer", "https://picsum.photos/640/480/?image=161", 620.596614303652213m, 86, 31.445602f },
                    { new Guid("7f1d2050-4757-56e3-8dec-00035299654b"), new Guid("f9d93c6d-09e8-f103-2279-2d08eeb69171"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new Guid("8f457a31-5463-05c0-29ae-2e46003ded60"), "Refined Wooden Tuna", "https://picsum.photos/640/480/?image=447", 534.718802927720296m, 20, 42.417393f },
                    { new Guid("ac769ba9-6305-a847-32a9-d630605409f7"), new Guid("647684b3-76c5-0519-1e33-43ad3be2ba79"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new Guid("8ead666e-5589-3921-763e-c9a379b0e549"), "Handmade Frozen Salad", "https://picsum.photos/640/480/?image=229", 740.485659108550456m, 69, 32.776962f }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "CommodityEntityId", "Description", "Stars", "Title" },
                values: new object[,]
                {
                    { new Guid("3ddcb314-a436-e733-f10b-999cfd52b623"), new Guid("7f1d2050-4757-56e3-8dec-00035299654b"), "Cum autem sequi adipisci omnis autem labore consequatur rerum. Iste possimus aut fugiat ab eum accusantium quia. Cum molestiae quo totam et et. Placeat ratione animi autem doloribus.", 5, "Quia nihil et et." },
                    { new Guid("440e6319-2db0-af0e-0fce-743dfb1b15a7"), new Guid("56847a0f-bfd5-8138-98a5-26a16c169187"), "Aut aut neque ipsum enim architecto ab. Laborum rem et optio et. Sed ut praesentium unde aut maxime. Blanditiis minima dicta doloremque qui dignissimos. Delectus aut dolor laborum sunt et ipsa.", 4, "Non ut consequuntur maiores." },
                    { new Guid("4a87e107-3527-78ce-58aa-8eeb7e28e27a"), new Guid("56847a0f-bfd5-8138-98a5-26a16c169187"), "Porro consequatur et assumenda. Et impedit eos necessitatibus temporibus voluptate expedita totam quaerat. Blanditiis beatae quis optio voluptatem sed et pariatur quibusdam.", 2, "Quaerat impedit debitis asperiores non animi similique." },
                    { new Guid("e0636ee1-029f-5e3c-5f57-69378cafbbd4"), new Guid("56847a0f-bfd5-8138-98a5-26a16c169187"), "Voluptate ducimus neque dolores. Explicabo optio voluptatem incidunt aut ut sint suscipit blanditiis delectus. Occaecati et eveniet pariatur totam minima quo veritatis et. Et quo voluptas recusandae voluptas iste libero. Non ea eos quibusdam laborum. Et ut est.", 5, "Error natus quaerat officiis." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("4d02891e-8511-25da-72c9-d9c78a5f05bb"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("ac769ba9-6305-a847-32a9-d630605409f7"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("bfb8062a-4445-df04-4016-8cb172475b5c"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("e50df1e0-76e8-54a9-a4ca-625c08963f21"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("3ddcb314-a436-e733-f10b-999cfd52b623"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("440e6319-2db0-af0e-0fce-743dfb1b15a7"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("4a87e107-3527-78ce-58aa-8eeb7e28e27a"));

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: new Guid("e0636ee1-029f-5e3c-5f57-69378cafbbd4"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4954fefa-151e-9441-e45d-c05e846e229d"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("647684b3-76c5-0519-1e33-43ad3be2ba79"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("56847a0f-bfd5-8138-98a5-26a16c169187"));

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: new Guid("7f1d2050-4757-56e3-8dec-00035299654b"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("8ead666e-5589-3921-763e-c9a379b0e549"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f07d68e8-f5ff-3f1f-9374-d671b54809ab"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f9d93c6d-09e8-f103-2279-2d08eeb69171"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("8f457a31-5463-05c0-29ae-2e46003ded60"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("166e5d30-2f53-fe75-979a-7a9394d3ee8a"), "Automotive" },
                    { new Guid("44400198-729b-ca78-7765-22a8e8c9e9e8"), "Electronics, Games & Toys" },
                    { new Guid("7f13c2b3-9ac5-d41a-7963-9eff0dee57c9"), "Clothing, Computers & Games" },
                    { new Guid("df69efcb-cb62-5881-4a8b-9b242c215ba4"), "Tools, Clothing & Toys" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CountryOfOrigin", "Description", "Logo", "Name" },
                values: new object[,]
                {
                    { new Guid("0f6b20b2-3679-486b-ed43-76c50f9f2100"), "New Caledonia", "Natus excepturi rem inventore est est consequatur corrupti. Quis repellat modi at necessitatibus molestiae dicta consectetur in. Numquam accusantium ea rerum suscipit natus magni. Ipsum explicabo eligendi. Illo pariatur eos molestiae illum accusantium aut ipsum.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/540.jpg", "Streich - MacGyver" },
                    { new Guid("3f699363-a183-b058-07fb-bc5cc9012d6e"), "Portugal", "Quis maxime sed architecto molestias aut et non quod. Molestiae voluptatem quasi quia. Tempora nulla assumenda illum iure nisi. Maiores explicabo laboriosam minima et. Accusantium autem repudiandae molestiae error laborum officia.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/214.jpg", "Ferry - McCullough" },
                    { new Guid("a4b2b288-760f-ccb4-668b-2b030f569781"), "Israel", "Sunt sint eos. Asperiores autem accusantium eligendi libero culpa. Est excepturi necessitatibus dicta officia. Animi magni nisi perferendis est temporibus sint cumque.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/790.jpg", "Greenholt - Stehr" },
                    { new Guid("f39c7659-6e31-8946-de32-1d0f1c777039"), "Belarus", "Fugit eos labore et eum dignissimos ut nulla quaerat modi. Vel praesentium perspiciatis sunt nam ipsa ut. Accusantium velit aut magnam unde. Et eaque voluptates nobis repellendus placeat nobis a architecto et. Distinctio ipsum reprehenderit incidunt deleniti aliquam perferendis aspernatur consequuntur.", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/346.jpg", "Bins Inc" }
                });

            migrationBuilder.InsertData(
                table: "Commodity",
                columns: new[] { "Id", "CategoryId", "Description", "ManufacturerId", "Name", "Picture", "Price", "Quantity", "Weight" },
                values: new object[,]
                {
                    { new Guid("064031c2-dfcf-0dfa-c2cf-736a82190788"), new Guid("7f13c2b3-9ac5-d41a-7963-9eff0dee57c9"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new Guid("a4b2b288-760f-ccb4-668b-2b030f569781"), "Intelligent Cotton Salad", "https://picsum.photos/640/480/?image=259", 345.165568973259688m, 55, 49.31029f },
                    { new Guid("06afb9db-f6a4-ac23-6430-e0e23b66282d"), new Guid("44400198-729b-ca78-7765-22a8e8c9e9e8"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new Guid("0f6b20b2-3679-486b-ed43-76c50f9f2100"), "Intelligent Frozen Ball", "https://picsum.photos/640/480/?image=76", 759.093057792165133m, 2, 28.71702f },
                    { new Guid("ae2d39c9-3a05-617c-c0fc-82c43fd6302f"), new Guid("166e5d30-2f53-fe75-979a-7a9394d3ee8a"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new Guid("a4b2b288-760f-ccb4-668b-2b030f569781"), "Small Soft Pizza", "https://picsum.photos/640/480/?image=801", 836.646045083702686m, 48, 57.776867f },
                    { new Guid("aee56139-bc98-d9d5-2aa5-ebb90c4f87aa"), new Guid("44400198-729b-ca78-7765-22a8e8c9e9e8"), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new Guid("0f6b20b2-3679-486b-ed43-76c50f9f2100"), "Handmade Plastic Chicken", "https://picsum.photos/640/480/?image=100", 351.237212416251532m, 48, 81.89171f }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "CommodityEntityId", "Description", "Stars", "Title" },
                values: new object[,]
                {
                    { new Guid("672dd54a-d42c-18ab-a4fd-e07a1cfd0863"), new Guid("064031c2-dfcf-0dfa-c2cf-736a82190788"), "Fuga mollitia deleniti autem nihil dolores molestias nesciunt vero laudantium. Recusandae non itaque sed nihil. Consequuntur porro recusandae similique odit voluptatem impedit. Assumenda doloribus impedit non eaque quaerat. Est aliquam quam autem veniam deserunt ullam debitis dolores. Harum omnis voluptatem velit.", 2, "Expedita minus autem molestiae id ea quasi." },
                    { new Guid("86493e3a-9441-93ab-f2d6-52242a9c4f59"), new Guid("ae2d39c9-3a05-617c-c0fc-82c43fd6302f"), "Itaque quia quam itaque maxime quisquam ducimus distinctio reprehenderit. Pariatur incidunt aut. Cumque nesciunt id et. Velit neque eius qui dolores aut exercitationem soluta. Sit sed cum voluptatem cumque reprehenderit distinctio consequatur minima sequi.", 5, "Laudantium nostrum sunt sapiente assumenda." },
                    { new Guid("92ec72f7-0616-730f-efed-14a93003e115"), new Guid("06afb9db-f6a4-ac23-6430-e0e23b66282d"), "Ut ut voluptatem. Voluptas ad aut consequatur similique quia ad. Soluta et earum deleniti et voluptatem rerum possimus quia. Odit enim qui et pariatur quia ut sint facere consectetur. Excepturi sit numquam doloremque expedita aperiam facilis et.", 5, "Minus beatae necessitatibus earum excepturi." },
                    { new Guid("de7a8bf9-0345-b1b9-dd98-f642cc19e350"), new Guid("ae2d39c9-3a05-617c-c0fc-82c43fd6302f"), "Dicta distinctio corporis officia velit eum error ab. Numquam vitae omnis tenetur tempora provident rem voluptatem est aliquid. Asperiores sed voluptatem in atque nisi quia dolores. Nihil praesentium occaecati porro aut et sint consequatur.", 3, "Distinctio animi tempore amet non ut rerum aut et velit." }
                });
        }
    }
}

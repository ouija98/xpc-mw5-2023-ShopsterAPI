﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopster.DAL;

#nullable disable

namespace Shopster.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shopster.DAL.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("647684b3-76c5-0519-1e33-43ad3be2ba79"),
                            Name = "Baby, Baby & Music"
                        },
                        new
                        {
                            Id = new Guid("f07d68e8-f5ff-3f1f-9374-d671b54809ab"),
                            Name = "Music"
                        },
                        new
                        {
                            Id = new Guid("f9d93c6d-09e8-f103-2279-2d08eeb69171"),
                            Name = "Outdoors & Grocery"
                        },
                        new
                        {
                            Id = new Guid("4954fefa-151e-9441-e45d-c05e846e229d"),
                            Name = "Kids & Beauty"
                        });
                });

            modelBuilder.Entity("Shopster.DAL.Entities.CommodityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Commodity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("56847a0f-bfd5-8138-98a5-26a16c169187"),
                            CategoryId = new Guid("f07d68e8-f5ff-3f1f-9374-d671b54809ab"),
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            ManufacturerId = new Guid("8f457a31-5463-05c0-29ae-2e46003ded60"),
                            Name = "Handmade Rubber Computer",
                            Picture = "https://picsum.photos/640/480/?image=161",
                            Price = 620.596614303652213m,
                            Quantity = 86,
                            Weight = 31.445602f
                        },
                        new
                        {
                            Id = new Guid("7f1d2050-4757-56e3-8dec-00035299654b"),
                            CategoryId = new Guid("f9d93c6d-09e8-f103-2279-2d08eeb69171"),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            ManufacturerId = new Guid("8f457a31-5463-05c0-29ae-2e46003ded60"),
                            Name = "Refined Wooden Tuna",
                            Picture = "https://picsum.photos/640/480/?image=447",
                            Price = 534.718802927720296m,
                            Quantity = 20,
                            Weight = 42.417393f
                        },
                        new
                        {
                            Id = new Guid("ac769ba9-6305-a847-32a9-d630605409f7"),
                            CategoryId = new Guid("647684b3-76c5-0519-1e33-43ad3be2ba79"),
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            ManufacturerId = new Guid("8ead666e-5589-3921-763e-c9a379b0e549"),
                            Name = "Handmade Frozen Salad",
                            Picture = "https://picsum.photos/640/480/?image=229",
                            Price = 740.485659108550456m,
                            Quantity = 69,
                            Weight = 32.776962f
                        },
                        new
                        {
                            Id = new Guid("4d02891e-8511-25da-72c9-d9c78a5f05bb"),
                            CategoryId = new Guid("4954fefa-151e-9441-e45d-c05e846e229d"),
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            ManufacturerId = new Guid("8f457a31-5463-05c0-29ae-2e46003ded60"),
                            Name = "Fantastic Concrete Chair",
                            Picture = "https://picsum.photos/640/480/?image=153",
                            Price = 991.495184142350836m,
                            Quantity = 2,
                            Weight = 35.32461f
                        });
                });

            modelBuilder.Entity("Shopster.DAL.Entities.ManufacturerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bfb8062a-4445-df04-4016-8cb172475b5c"),
                            CountryOfOrigin = "Switzerland",
                            Description = "Repudiandae aut aliquid qui. Consequatur ut deleniti incidunt soluta. Autem nulla nihil. Iure laborum aperiam. Voluptatem esse dolorem autem ut qui sint sed. Et esse dicta consequuntur et exercitationem architecto voluptas occaecati est.",
                            Logo = "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/70.jpg",
                            Name = "Zieme - Lebsack"
                        },
                        new
                        {
                            Id = new Guid("8ead666e-5589-3921-763e-c9a379b0e549"),
                            CountryOfOrigin = "China",
                            Description = "Illum animi est est nesciunt qui vitae iusto non enim. Delectus recusandae modi officia debitis labore iure facere. Molestiae quo laboriosam asperiores suscipit quaerat quam ratione. Voluptas ad est eveniet qui rerum reprehenderit voluptatem. Illum nemo eius sit quae earum porro. Assumenda est dolores eos laboriosam voluptatibus est est aut minus.",
                            Logo = "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/341.jpg",
                            Name = "Langworth - Lebsack"
                        },
                        new
                        {
                            Id = new Guid("e50df1e0-76e8-54a9-a4ca-625c08963f21"),
                            CountryOfOrigin = "Somalia",
                            Description = "Velit velit aut. Nesciunt cupiditate officia ducimus aut cum. Et voluptatem eveniet quaerat qui occaecati quos et quos. Saepe debitis consequuntur iure.",
                            Logo = "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/826.jpg",
                            Name = "Murray Inc"
                        },
                        new
                        {
                            Id = new Guid("8f457a31-5463-05c0-29ae-2e46003ded60"),
                            CountryOfOrigin = "Estonia",
                            Description = "Quidem qui tempora voluptatum suscipit. Quia et corrupti numquam qui mollitia cupiditate cumque et autem. Possimus aut placeat dolore rem eum et reiciendis voluptatem.",
                            Logo = "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/814.jpg",
                            Name = "Buckridge, Robel and Bashirian"
                        });
                });

            modelBuilder.Entity("Shopster.DAL.Entities.RatingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommodityEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommodityEntityId");

                    b.ToTable("Rating");

                    b.HasData(
                        new
                        {
                            Id = new Guid("440e6319-2db0-af0e-0fce-743dfb1b15a7"),
                            CommodityEntityId = new Guid("56847a0f-bfd5-8138-98a5-26a16c169187"),
                            Description = "Aut aut neque ipsum enim architecto ab. Laborum rem et optio et. Sed ut praesentium unde aut maxime. Blanditiis minima dicta doloremque qui dignissimos. Delectus aut dolor laborum sunt et ipsa.",
                            Stars = 4,
                            Title = "Non ut consequuntur maiores."
                        },
                        new
                        {
                            Id = new Guid("4a87e107-3527-78ce-58aa-8eeb7e28e27a"),
                            CommodityEntityId = new Guid("56847a0f-bfd5-8138-98a5-26a16c169187"),
                            Description = "Porro consequatur et assumenda. Et impedit eos necessitatibus temporibus voluptate expedita totam quaerat. Blanditiis beatae quis optio voluptatem sed et pariatur quibusdam.",
                            Stars = 2,
                            Title = "Quaerat impedit debitis asperiores non animi similique."
                        },
                        new
                        {
                            Id = new Guid("3ddcb314-a436-e733-f10b-999cfd52b623"),
                            CommodityEntityId = new Guid("7f1d2050-4757-56e3-8dec-00035299654b"),
                            Description = "Cum autem sequi adipisci omnis autem labore consequatur rerum. Iste possimus aut fugiat ab eum accusantium quia. Cum molestiae quo totam et et. Placeat ratione animi autem doloribus.",
                            Stars = 5,
                            Title = "Quia nihil et et."
                        },
                        new
                        {
                            Id = new Guid("e0636ee1-029f-5e3c-5f57-69378cafbbd4"),
                            CommodityEntityId = new Guid("56847a0f-bfd5-8138-98a5-26a16c169187"),
                            Description = "Voluptate ducimus neque dolores. Explicabo optio voluptatem incidunt aut ut sint suscipit blanditiis delectus. Occaecati et eveniet pariatur totam minima quo veritatis et. Et quo voluptas recusandae voluptas iste libero. Non ea eos quibusdam laborum. Et ut est.",
                            Stars = 5,
                            Title = "Error natus quaerat officiis."
                        });
                });

            modelBuilder.Entity("Shopster.DAL.Entities.CommodityEntity", b =>
                {
                    b.HasOne("Shopster.DAL.Entities.CategoryEntity", "Category")
                        .WithMany("Commodities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopster.DAL.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("Commodities")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Shopster.DAL.Entities.RatingEntity", b =>
                {
                    b.HasOne("Shopster.DAL.Entities.CommodityEntity", "Commodity")
                        .WithMany("Ratings")
                        .HasForeignKey("CommodityEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commodity");
                });

            modelBuilder.Entity("Shopster.DAL.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Commodities");
                });

            modelBuilder.Entity("Shopster.DAL.Entities.CommodityEntity", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Shopster.DAL.Entities.ManufacturerEntity", b =>
                {
                    b.Navigation("Commodities");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopster.Shopster.DAL.AppDbContext;

#nullable disable

namespace Shopster.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230418132425_CommoditiesTest")]
    partial class CommoditiesTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shopster.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7397a2ce-af81-4d4b-84c1-2e37984e5df2"),
                            Name = "ctg1"
                        },
                        new
                        {
                            Id = new Guid("9bba9fc0-674a-449a-8d98-349555819fa0"),
                            Name = "ctg3"
                        },
                        new
                        {
                            Id = new Guid("b1d2ee9b-cdfa-4d9a-9d29-49d52123b02e"),
                            Name = "ctg5"
                        },
                        new
                        {
                            Id = new Guid("c7daa61e-4cb9-4e1f-a02f-1ad327200a47"),
                            Name = "ctg6"
                        });
                });

            modelBuilder.Entity("Shopster.Entities.CommodityEntity", b =>
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
                            Id = new Guid("4e170f02-35e2-445a-96ce-fd4e65b35d4b"),
                            CategoryId = new Guid("7397a2ce-af81-4d4b-84c1-2e37984e5df2"),
                            Description = "desc1",
                            ManufacturerId = new Guid("11d26544-a730-427a-8b30-ba7d154d31ae"),
                            Name = "cmd1",
                            Picture = "picture.jpg",
                            Price = 10m,
                            Quantity = 2,
                            Weight = 20f
                        },
                        new
                        {
                            Id = new Guid("f31e115b-3e23-47a3-824d-68c0c5490af8"),
                            CategoryId = new Guid("9bba9fc0-674a-449a-8d98-349555819fa0"),
                            Description = "desc2",
                            ManufacturerId = new Guid("81363ec8-2b79-46f8-95ca-e47790135731"),
                            Name = "cmd2",
                            Picture = "picture.jpg",
                            Price = 1m,
                            Quantity = 2,
                            Weight = 5f
                        },
                        new
                        {
                            Id = new Guid("26e1b935-9c8d-4d74-9957-96d96020b74f"),
                            CategoryId = new Guid("c7daa61e-4cb9-4e1f-a02f-1ad327200a47"),
                            Description = "desc3",
                            ManufacturerId = new Guid("11d26544-a730-427a-8b30-ba7d154d31ae"),
                            Name = "cmd3",
                            Picture = "picture.jpg",
                            Price = 23254m,
                            Quantity = 20,
                            Weight = 15f
                        },
                        new
                        {
                            Id = new Guid("84b2d548-8371-4cdb-9d69-abd0e8dbd3d7"),
                            CategoryId = new Guid("c7daa61e-4cb9-4e1f-a02f-1ad327200a47"),
                            Description = "desc4",
                            ManufacturerId = new Guid("fc12bd43-cb22-42ce-a0e8-f5d98267be06"),
                            Name = "cmd4",
                            Picture = "picture.jpg",
                            Price = 55m,
                            Quantity = 10,
                            Weight = 15f
                        });
                });

            modelBuilder.Entity("Shopster.Entities.ManufacturerEntity", b =>
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
                            Id = new Guid("ec2e0405-2227-4510-89e3-8dcb6c7e76b6"),
                            CountryOfOrigin = "CZ",
                            Description = "desc1",
                            Logo = "logo1.png",
                            Name = "manu1"
                        },
                        new
                        {
                            Id = new Guid("81363ec8-2b79-46f8-95ca-e47790135731"),
                            CountryOfOrigin = "CZ",
                            Description = "desc2",
                            Logo = "logo2.png",
                            Name = "manu2"
                        },
                        new
                        {
                            Id = new Guid("11d26544-a730-427a-8b30-ba7d154d31ae"),
                            CountryOfOrigin = "CZ",
                            Description = "desc3",
                            Logo = "logo3.png",
                            Name = "manu3"
                        },
                        new
                        {
                            Id = new Guid("fc12bd43-cb22-42ce-a0e8-f5d98267be06"),
                            CountryOfOrigin = "CZ",
                            Description = "desc4",
                            Logo = "logo4.png",
                            Name = "manu4"
                        });
                });

            modelBuilder.Entity("Shopster.Entities.RatingEntity", b =>
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
                            Id = new Guid("93bea869-8421-48c2-bcea-474b0a91a7af"),
                            CommodityEntityId = new Guid("4e170f02-35e2-445a-96ce-fd4e65b35d4b"),
                            Description = "desc1",
                            Stars = 1,
                            Title = "title1"
                        });
                });

            modelBuilder.Entity("Shopster.Entities.CommodityEntity", b =>
                {
                    b.HasOne("Shopster.Entities.CategoryEntity", "Category")
                        .WithMany("Commodities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopster.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("Commodities")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Shopster.Entities.RatingEntity", b =>
                {
                    b.HasOne("Shopster.Entities.CommodityEntity", "Commodity")
                        .WithMany("Ratings")
                        .HasForeignKey("CommodityEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commodity");
                });

            modelBuilder.Entity("Shopster.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Commodities");
                });

            modelBuilder.Entity("Shopster.Entities.CommodityEntity", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Shopster.Entities.ManufacturerEntity", b =>
                {
                    b.Navigation("Commodities");
                });
#pragma warning restore 612, 618
        }
    }
}
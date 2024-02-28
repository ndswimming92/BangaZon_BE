﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangaZon_ND.Migrations
{
    [DbContext(typeof(BangaZonDbContext))]
    [Migration("20240227031433_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BangaZon_ND.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemCount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemCount = 1,
                            Name = "Tent"
                        },
                        new
                        {
                            Id = 2,
                            ItemCount = 2,
                            Name = "RV"
                        },
                        new
                        {
                            Id = 3,
                            ItemCount = 10,
                            Name = "Primitive"
                        },
                        new
                        {
                            Id = 4,
                            ItemCount = 12,
                            Name = "Hammock"
                        });
                });

            modelBuilder.Entity("BangaZon_ND.Models.Order", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool?>("OrderStatus")
                        .HasColumnType("boolean");

                    b.Property<int?>("PaymentType")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductsId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderDate = new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5622),
                            OrderStatus = true,
                            PaymentType = 1,
                            ProductsId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderDate = new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5712),
                            OrderStatus = true,
                            PaymentType = 2,
                            ProductsId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            OrderDate = new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5715),
                            OrderStatus = false,
                            PaymentType = 1,
                            ProductsId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BangaZon_ND.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Type1"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Type2"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Type3"
                        });
                });

            modelBuilder.Entity("BangaZon_ND.Models.Product", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("PricePerUnit")
                        .HasColumnType("integer");

                    b.Property<int?>("QuantityAvailable")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("TimePosted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<bool?>("UserIsSeller")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Description 1",
                            PricePerUnit = 100,
                            QuantityAvailable = 10,
                            TimePosted = new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5787),
                            Title = "Product 1",
                            UserId = 1,
                            UserIsSeller = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Description 2",
                            PricePerUnit = 200,
                            QuantityAvailable = 20,
                            TimePosted = new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5793),
                            Title = "Product 2",
                            UserId = 2,
                            UserIsSeller = false
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Description 3",
                            PricePerUnit = 300,
                            QuantityAvailable = 30,
                            TimePosted = new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5798),
                            Title = "Product 3",
                            UserId = 3,
                            UserIsSeller = true
                        });
                });

            modelBuilder.Entity("BangaZon_ND.Models.ProductOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ProductOrders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 3,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("BangaZon_ND.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool?>("IsSeller")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user1@example.com",
                            IsSeller = true,
                            Name = "Nicholas Davidson"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user2@example.com",
                            IsSeller = false,
                            Name = "James Collier"
                        },
                        new
                        {
                            Id = 3,
                            Email = "user3@example.com",
                            IsSeller = false,
                            Name = "Willy Wonka"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
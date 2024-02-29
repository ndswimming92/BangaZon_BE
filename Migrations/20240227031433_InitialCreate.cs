using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangaZon_ND.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ItemCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PaymentType = table.Column<int>(type: "integer", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OrderStatus = table.Column<bool>(type: "boolean", nullable: true),
                    ProductsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: true),
                    PricePerUnit = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    TimePosted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserIsSeller = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsSeller = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ItemCount", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Tent" },
                    { 2, 2, "RV" },
                    { 3, 10, "Primitive" },
                    { 4, 12, "Hammock" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "OrderStatus", "PaymentType", "ProductsId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5622), true, 1, 1, 1 },
                    { 2, new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5712), true, 2, 2, 2 },
                    { 3, new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5715), false, 1, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Type1" },
                    { 2, "Type2" },
                    { 3, "Type3" }
                });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "Id", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "PricePerUnit", "QuantityAvailable", "TimePosted", "Title", "UserId", "UserIsSeller" },
                values: new object[,]
                {
                    { 1, 1, "Description 1", 100, 10, new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5787), "Product 1", 1, true },
                    { 2, 2, "Description 2", 200, 20, new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5793), "Product 2", 2, false },
                    { 3, 3, "Description 3", 300, 30, new DateTime(2024, 2, 26, 21, 14, 33, 228, DateTimeKind.Local).AddTicks(5798), "Product 3", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsSeller", "Name" },
                values: new object[,]
                {
                    { 1, "user1@example.com", true, "Nicholas Davidson" },
                    { 2, "user2@example.com", false, "James Collier" },
                    { 3, "user3@example.com", false, "Willy Wonka" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

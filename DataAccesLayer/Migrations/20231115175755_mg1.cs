using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookTableModels",
                columns: table => new
                {
                    BookTableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Persons = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookTableModels", x => x.BookTableID);
                });

            migrationBuilder.CreateTable(
                name: "cartModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoryModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "foodModels",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodIngredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStatus = table.Column<bool>(type: "bit", nullable: false),
                    FoodImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodDiscount = table.Column<bool>(type: "bit", nullable: false),
                    FoodPrice = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FoodDiscountPrice = table.Column<long>(type: "bigint", nullable: false),
                    CartModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodModels", x => x.FoodID);
                    table.ForeignKey(
                        name: "FK_foodModels_cartModels_CartModelId",
                        column: x => x.CartModelId,
                        principalTable: "cartModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_foodModels_CartModelId",
                table: "foodModels",
                column: "CartModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookTableModels");

            migrationBuilder.DropTable(
                name: "categoryModels");

            migrationBuilder.DropTable(
                name: "foodModels");

            migrationBuilder.DropTable(
                name: "userModels");

            migrationBuilder.DropTable(
                name: "cartModels");
        }
    }
}

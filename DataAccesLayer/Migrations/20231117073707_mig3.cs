using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "foodModels",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "FoodDiscount",
                table: "foodModels",
                newName: "FoodDiscountStatus");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "foodModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "foodModels");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "foodModels",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "FoodDiscountStatus",
                table: "foodModels",
                newName: "FoodDiscount");
        }
    }
}

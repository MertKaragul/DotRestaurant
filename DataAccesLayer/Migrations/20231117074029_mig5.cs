using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foodModels_cartModels_CartModelId",
                table: "foodModels");

            migrationBuilder.DropIndex(
                name: "IX_foodModels_CartModelId",
                table: "foodModels");

            migrationBuilder.DropColumn(
                name: "CartModelId",
                table: "foodModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartModelId",
                table: "foodModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_foodModels_CartModelId",
                table: "foodModels",
                column: "CartModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_foodModels_cartModels_CartModelId",
                table: "foodModels",
                column: "CartModelId",
                principalTable: "cartModels",
                principalColumn: "Id");
        }
    }
}

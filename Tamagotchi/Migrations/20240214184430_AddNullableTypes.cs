using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamagotchi.Migrations
{
    public partial class AddNullableTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Foods_FoodId",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Toys_ToyId",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<int>(
                name: "ToyId",
                table: "InventoryItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FoodId",
                table: "InventoryItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Foods_FoodId",
                table: "InventoryItems",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Toys_ToyId",
                table: "InventoryItems",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "ToyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Foods_FoodId",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Toys_ToyId",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<int>(
                name: "ToyId",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FoodId",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Foods_FoodId",
                table: "InventoryItems",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Toys_ToyId",
                table: "InventoryItems",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "ToyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

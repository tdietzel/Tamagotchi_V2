using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamagotchi.Migrations
{
    public partial class AddUserFoodInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Foods",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UserId",
                table: "Foods",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_AspNetUsers_UserId",
                table: "Foods",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_AspNetUsers_UserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_UserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Foods");
        }
    }
}

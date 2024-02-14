using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamagotchi.Migrations
{
    public partial class AddSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shops",
                column: "ShopId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Fullness", "ItemType", "Name", "Quantity", "ShopId" },
                values: new object[,]
                {
                    { 1, 10, "Food", "Kibble", 1, 1 },
                    { 2, 20, "Food", "Canned", 1, 1 },
                    { 3, 35, "Food", "Filet-Mignon", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Toys",
                columns: new[] { "ToyId", "Excitement", "ItemType", "Name", "Quantity", "ShopId" },
                values: new object[,]
                {
                    { 1, 20, "Toy", "Ball", 1, 1 },
                    { 2, 30, "Toy", "Bone", 1, 1 },
                    { 3, 50, "Toy", "Frisbee", 1, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "ToyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "ToyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Toys",
                keyColumn: "ToyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: 1);
        }
    }
}

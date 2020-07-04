using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAPI.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Foods_food_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_food_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "food_Id",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "food_Id",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_food_Id",
                table: "Orders",
                column: "food_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Foods_food_Id",
                table: "Orders",
                column: "food_Id",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAPI.Migrations
{
    public partial class update15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Orders_Bookings_Food_OrderId",
                table: "Food_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food_Orders",
                table: "Food_Orders");

            migrationBuilder.DropColumn(
                name: "Food_OrderId",
                table: "Food_Orders");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Food_Orders",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "booking_Id",
                table: "Food_Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food_Orders",
                table: "Food_Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Orders_booking_Id",
                table: "Food_Orders",
                column: "booking_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Orders_Bookings_booking_Id",
                table: "Food_Orders",
                column: "booking_Id",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Orders_Bookings_booking_Id",
                table: "Food_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food_Orders",
                table: "Food_Orders");

            migrationBuilder.DropIndex(
                name: "IX_Food_Orders_booking_Id",
                table: "Food_Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Food_Orders");

            migrationBuilder.DropColumn(
                name: "booking_Id",
                table: "Food_Orders");

            migrationBuilder.AddColumn<int>(
                name: "Food_OrderId",
                table: "Food_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food_Orders",
                table: "Food_Orders",
                column: "Food_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Orders_Bookings_Food_OrderId",
                table: "Food_Orders",
                column: "Food_OrderId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

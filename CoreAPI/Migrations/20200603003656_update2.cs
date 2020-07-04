using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAPI.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_orders_order_Id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_bookings_booking_Id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_booking_Id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_bookings_order_Id",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "booking_Id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "order_Id",
                table: "bookings");

            migrationBuilder.AddColumn<string>(
                name: "ReviewContent",
                table: "reviews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderDiscountPercentage",
                table: "foodOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "OrderId");

            migrationBuilder.CreateTable(
                name: "food_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    OrderPrice = table.Column<float>(nullable: false),
                    food_Id = table.Column<int>(nullable: true),
                    order_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_food_Orders_foods_food_Id",
                        column: x => x.food_Id,
                        principalTable: "foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_food_Orders_orders_order_Id",
                        column: x => x.order_Id,
                        principalTable: "orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_food_Orders_food_Id",
                table: "food_Orders",
                column: "food_Id");

            migrationBuilder.CreateIndex(
                name: "IX_food_Orders_order_Id",
                table: "food_Orders",
                column: "order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_bookings_OrderId",
                table: "orders",
                column: "OrderId",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_bookings_OrderId",
                table: "orders");

            migrationBuilder.DropTable(
                name: "food_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ReviewContent",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OrderDiscountPercentage",
                table: "foodOffers");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "reviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "booking_Id",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "order_Id",
                table: "bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_booking_Id",
                table: "orders",
                column: "booking_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_order_Id",
                table: "bookings",
                column: "order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_orders_order_Id",
                table: "bookings",
                column: "order_Id",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_bookings_booking_Id",
                table: "orders",
                column: "booking_Id",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

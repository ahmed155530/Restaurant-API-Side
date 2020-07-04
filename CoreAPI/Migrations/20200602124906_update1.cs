using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAPI.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "foodCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DiscountPercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NO = table.Column<int>(nullable: false),
                    NOofPersons = table.Column<int>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    foodCategory_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_foods_foodCategories_foodCategory_Id",
                        column: x => x.foodCategory_Id,
                        principalTable: "foodCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "foodOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    offer_Id = table.Column<int>(nullable: true),
                    food_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_foodOffers_foods_food_Id",
                        column: x => x.food_Id,
                        principalTable: "foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_foodOffers_offers_offer_Id",
                        column: x => x.offer_Id,
                        principalTable: "offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true),
                    food_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_images_foods_food_Id",
                        column: x => x.food_Id,
                        principalTable: "foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    PostingDate = table.Column<DateTime>(nullable: false),
                    food_Id = table.Column<int>(nullable: true),
                    customer_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_customers_customer_Id",
                        column: x => x.customer_Id,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviews_foods_food_Id",
                        column: x => x.food_Id,
                        principalTable: "foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    food_Id = table.Column<int>(nullable: true),
                    booking_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_foods_food_Id",
                        column: x => x.food_Id,
                        principalTable: "foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    ReservedDate = table.Column<DateTime>(nullable: false),
                    CheckinTime = table.Column<DateTime>(nullable: false),
                    CheckoutTime = table.Column<DateTime>(nullable: false),
                    customer_Id = table.Column<int>(nullable: true),
                    table_Id = table.Column<int>(nullable: true),
                    order_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookings_customers_customer_Id",
                        column: x => x.customer_Id,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bookings_orders_order_Id",
                        column: x => x.order_Id,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bookings_tables_table_Id",
                        column: x => x.table_Id,
                        principalTable: "tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_customer_Id",
                table: "bookings",
                column: "customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_order_Id",
                table: "bookings",
                column: "order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_table_Id",
                table: "bookings",
                column: "table_Id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_UserId",
                table: "customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_foodOffers_food_Id",
                table: "foodOffers",
                column: "food_Id");

            migrationBuilder.CreateIndex(
                name: "IX_foodOffers_offer_Id",
                table: "foodOffers",
                column: "offer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_foods_foodCategory_Id",
                table: "foods",
                column: "foodCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_images_food_Id",
                table: "images",
                column: "food_Id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_booking_Id",
                table: "orders",
                column: "booking_Id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_food_Id",
                table: "orders",
                column: "food_Id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_customer_Id",
                table: "reviews",
                column: "customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_food_Id",
                table: "reviews",
                column: "food_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_bookings_booking_Id",
                table: "orders",
                column: "booking_Id",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_customers_customer_Id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_orders_order_Id",
                table: "bookings");

            migrationBuilder.DropTable(
                name: "foodOffers");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "foods");

            migrationBuilder.DropTable(
                name: "tables");

            migrationBuilder.DropTable(
                name: "foodCategories");
        }
    }
}

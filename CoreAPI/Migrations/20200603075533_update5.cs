using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAPI.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_customers_customer_Id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_tables_table_Id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_customers_AspNetUsers_UserId",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "FK_food_Orders_foods_food_Id",
                table: "food_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_food_Orders_orders_order_Id",
                table: "food_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_foodOffers_foods_food_Id",
                table: "foodOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_foodOffers_offers_offer_Id",
                table: "foodOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_foods_foodCategories_foodCategory_Id",
                table: "foods");

            migrationBuilder.DropForeignKey(
                name: "FK_images_foods_food_Id",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_bookings_OrderId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_foods_food_Id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_customers_customer_Id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_foods_food_Id",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tables",
                table: "tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reviews",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_offers",
                table: "offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_images",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_foods",
                table: "foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_foodOffers",
                table: "foodOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_foodCategories",
                table: "foodCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_food_Orders",
                table: "food_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookings",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "tables");

            migrationBuilder.DropColumn(
                name: "OrderDiscountPercentage",
                table: "foodOffers");

            migrationBuilder.RenameTable(
                name: "tables",
                newName: "Tables");

            migrationBuilder.RenameTable(
                name: "reviews",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "offers",
                newName: "Offers");

            migrationBuilder.RenameTable(
                name: "images",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "foods",
                newName: "Foods");

            migrationBuilder.RenameTable(
                name: "foodOffers",
                newName: "FoodOffers");

            migrationBuilder.RenameTable(
                name: "foodCategories",
                newName: "FoodCategories");

            migrationBuilder.RenameTable(
                name: "food_Orders",
                newName: "Food_Orders");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "bookings",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_food_Id",
                table: "Reviews",
                newName: "IX_Reviews_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_customer_Id",
                table: "Reviews",
                newName: "IX_Reviews_customer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_food_Id",
                table: "Orders",
                newName: "IX_Orders_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_images_food_Id",
                table: "Images",
                newName: "IX_Images_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_foods_foodCategory_Id",
                table: "Foods",
                newName: "IX_Foods_foodCategory_Id");

            migrationBuilder.RenameIndex(
                name: "IX_foodOffers_offer_Id",
                table: "FoodOffers",
                newName: "IX_FoodOffers_offer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_foodOffers_food_Id",
                table: "FoodOffers",
                newName: "IX_FoodOffers_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_food_Orders_order_Id",
                table: "Food_Orders",
                newName: "IX_Food_Orders_order_Id");

            migrationBuilder.RenameIndex(
                name: "IX_food_Orders_food_Id",
                table: "Food_Orders",
                newName: "IX_Food_Orders_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_customers_UserId",
                table: "Customers",
                newName: "IX_Customers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_table_Id",
                table: "Bookings",
                newName: "IX_Bookings_table_Id");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_customer_Id",
                table: "Bookings",
                newName: "IX_Bookings_customer_Id");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentage",
                table: "FoodOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOffers",
                table: "FoodOffers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodCategories",
                table: "FoodCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food_Orders",
                table: "Food_Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_customer_Id",
                table: "Bookings",
                column: "customer_Id",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tables_table_Id",
                table: "Bookings",
                column: "table_Id",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Orders_Foods_food_Id",
                table: "Food_Orders",
                column: "food_Id",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Orders_Orders_order_Id",
                table: "Food_Orders",
                column: "order_Id",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOffers_Foods_food_Id",
                table: "FoodOffers",
                column: "food_Id",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOffers_Offers_offer_Id",
                table: "FoodOffers",
                column: "offer_Id",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodCategories_foodCategory_Id",
                table: "Foods",
                column: "foodCategory_Id",
                principalTable: "FoodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Foods_food_Id",
                table: "Images",
                column: "food_Id",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bookings_OrderId",
                table: "Orders",
                column: "OrderId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Foods_food_Id",
                table: "Orders",
                column: "food_Id",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_customer_Id",
                table: "Reviews",
                column: "customer_Id",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Foods_food_Id",
                table: "Reviews",
                column: "food_Id",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_customer_Id",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tables_table_Id",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Orders_Foods_food_Id",
                table: "Food_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Orders_Orders_order_Id",
                table: "Food_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOffers_Foods_food_Id",
                table: "FoodOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOffers_Offers_offer_Id",
                table: "FoodOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodCategories_foodCategory_Id",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Foods_food_Id",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bookings_OrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Foods_food_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_customer_Id",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Foods_food_Id",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOffers",
                table: "FoodOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodCategories",
                table: "FoodCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food_Orders",
                table: "Food_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "FoodOffers");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "tables");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "reviews");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "offers");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "images");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "foods");

            migrationBuilder.RenameTable(
                name: "FoodOffers",
                newName: "foodOffers");

            migrationBuilder.RenameTable(
                name: "FoodCategories",
                newName: "foodCategories");

            migrationBuilder.RenameTable(
                name: "Food_Orders",
                newName: "food_Orders");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "customers");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_food_Id",
                table: "reviews",
                newName: "IX_reviews_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_customer_Id",
                table: "reviews",
                newName: "IX_reviews_customer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_food_Id",
                table: "orders",
                newName: "IX_orders_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Images_food_Id",
                table: "images",
                newName: "IX_images_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_foodCategory_Id",
                table: "foods",
                newName: "IX_foods_foodCategory_Id");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOffers_offer_Id",
                table: "foodOffers",
                newName: "IX_foodOffers_offer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOffers_food_Id",
                table: "foodOffers",
                newName: "IX_foodOffers_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Food_Orders_order_Id",
                table: "food_Orders",
                newName: "IX_food_Orders_order_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Food_Orders_food_Id",
                table: "food_Orders",
                newName: "IX_food_Orders_food_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserId",
                table: "customers",
                newName: "IX_customers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_table_Id",
                table: "bookings",
                newName: "IX_bookings_table_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_customer_Id",
                table: "bookings",
                newName: "IX_bookings_customer_Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "tables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderDiscountPercentage",
                table: "foodOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tables",
                table: "tables",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reviews",
                table: "reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_offers",
                table: "offers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_images",
                table: "images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_foods",
                table: "foods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_foodOffers",
                table: "foodOffers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_foodCategories",
                table: "foodCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_food_Orders",
                table: "food_Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookings",
                table: "bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_customers_customer_Id",
                table: "bookings",
                column: "customer_Id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_tables_table_Id",
                table: "bookings",
                column: "table_Id",
                principalTable: "tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_customers_AspNetUsers_UserId",
                table: "customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_food_Orders_foods_food_Id",
                table: "food_Orders",
                column: "food_Id",
                principalTable: "foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_food_Orders_orders_order_Id",
                table: "food_Orders",
                column: "order_Id",
                principalTable: "orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_foodOffers_foods_food_Id",
                table: "foodOffers",
                column: "food_Id",
                principalTable: "foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_foodOffers_offers_offer_Id",
                table: "foodOffers",
                column: "offer_Id",
                principalTable: "offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_foods_foodCategories_foodCategory_Id",
                table: "foods",
                column: "foodCategory_Id",
                principalTable: "foodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_images_foods_food_Id",
                table: "images",
                column: "food_Id",
                principalTable: "foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_bookings_OrderId",
                table: "orders",
                column: "OrderId",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_foods_food_Id",
                table: "orders",
                column: "food_Id",
                principalTable: "foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_customers_customer_Id",
                table: "reviews",
                column: "customer_Id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_foods_food_Id",
                table: "reviews",
                column: "food_Id",
                principalTable: "foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

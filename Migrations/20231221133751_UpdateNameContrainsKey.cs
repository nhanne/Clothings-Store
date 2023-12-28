using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothings_Store.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameContrainsKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Order__PaymentId__32AB8735",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK__Order__Status__2FCF1A8A",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__Stock__2180FB33",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__Product__Categor__267ABA7A",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK__Stock__ColorId__19DFD96B",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK__Stock__ProductId__18EBB532",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK__Stock__SizeId__1AD3FDA4",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Stock__3214EC078808D165",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Sizes__3214EC07D711A6F5",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Promotio__2CB9556BBEE408D1",
                table: "Promotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Payment__3214EC07CB929B86",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__tmp_ms_x__3A15923EEC714ED5",
                table: "OrderStatus");


            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Colors__3214EC074B6E2D47",
                table: "Colors");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Promotion",
                table: "Promotions",
                column: "promotion_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderStatus",
                table: "OrderStatus",
                column: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrderDetail",
                table: "OrderDetail",
                columns: new[] { "OrderId", "StockId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Order__PaymentId",
                table: "Order",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Order__Status",
                table: "Order",
                column: "Status",
                principalTable: "OrderStatus",
                principalColumn: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDetail__OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDetail__StockId",
                table: "OrderDetail",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Product__CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Stock__ColorId",
                table: "Stock",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Stock__ProductId",
                table: "Stock",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Stock__SizeId",
                table: "Stock",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Order__PaymentId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK__Order__Status",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDetail__OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDetail__StockId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__Product__CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK__Stock__ColorId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK__Stock__ProductId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK__Stock__SizeId",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Stock",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Promotion",
                table: "Promotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Payment",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderStatus",
                table: "OrderStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Colors",
                table: "Colors");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Stock__3214EC078808D165",
                table: "Stock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Sizes__3214EC07D711A6F5",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Promotio__2CB9556BBEE408D1",
                table: "Promotions",
                column: "promotion_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Payment__3214EC07CB929B86",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__tmp_ms_x__3A15923EEC714ED5",
                table: "OrderStatus",
                column: "Status");


            migrationBuilder.AddPrimaryKey(
                name: "PK__tmp_ms_x__3214EC076065A524",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Colors__3214EC074B6E2D47",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Order__PaymentId__32AB8735",
                table: "Order",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Order__Status__2FCF1A8A",
                table: "Order",
                column: "Status",
                principalTable: "OrderStatus",
                principalColumn: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__Order__2EDAF651",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__Stock__2180FB33",
                table: "OrderDetail",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Product__Categor__267ABA7A",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Stock__ColorId__19DFD96B",
                table: "Stock",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Stock__ProductId__18EBB532",
                table: "Stock",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Stock__SizeId__1AD3FDA4",
                table: "Stock",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothings_Store.Migrations
{
    /// <inheritdoc />
    public partial class NewInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Order__CustomerI__30C33EC3",
                table: "Order");
            migrationBuilder.DropPrimaryKey(
                name: "PK__Customer__3214EC0739C90AAD",
                table: "Customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Customer",
                table: "Customer",
                column: "Id");
            migrationBuilder.AddForeignKey(
                name: "FK__Order__CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

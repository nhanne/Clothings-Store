using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothings_Store.Migrations
{
    /// <inheritdoc />
    public partial class DropTable_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Order__CustomerId",
                table: "Order");
            migrationBuilder.Sql("DROP TABLE IF EXISTS Customer;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

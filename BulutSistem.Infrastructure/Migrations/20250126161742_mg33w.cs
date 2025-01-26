using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulutSistem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg33w : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock_Quantity",
                table: "Products",
                newName: "StockQuantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "Stock_Quantity");
        }
    }
}

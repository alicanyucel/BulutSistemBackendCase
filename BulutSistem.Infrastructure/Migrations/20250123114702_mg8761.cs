using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulutSistem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg8761 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VariantName",
                table: "Variants",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Variants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductVariants");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Variants",
                newName: "VariantName");
        }
    }
}

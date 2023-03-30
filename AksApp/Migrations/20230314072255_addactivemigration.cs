using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AksApp.Migrations
{
    /// <inheritdoc />
    public partial class addactivemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subcategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");
        }
    }
}

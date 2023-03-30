using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AksApp.Migrations
{
    /// <inheritdoc />
    public partial class changesubcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category_Name",
                table: "Subcategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Name",
                table: "Subcategories");
        }
    }
}

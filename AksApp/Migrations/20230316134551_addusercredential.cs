using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AksApp.Migrations
{
    /// <inheritdoc />
    public partial class addusercredential : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KeepLoggedIn",
                table: "userCredentials",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeepLoggedIn",
                table: "userCredentials");
        }
    }
}

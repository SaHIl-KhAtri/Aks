using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AksApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDbContextone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userCredentials",
                table: "userCredentials");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "userCredentials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "userCredentials",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCredentials",
                table: "userCredentials",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userCredentials",
                table: "userCredentials");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "userCredentials");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "userCredentials",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCredentials",
                table: "userCredentials",
                column: "Email");
        }
    }
}

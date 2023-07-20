using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spargo_Technology_Test_Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVarCharType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stocks",
                type: "NVARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "NVARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Pharmacy",
                type: "NVARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pharmacy",
                type: "NVARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Pharmacy",
                type: "NVARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stocks",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Pharmacy",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pharmacy",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Pharmacy",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)");
        }
    }
}

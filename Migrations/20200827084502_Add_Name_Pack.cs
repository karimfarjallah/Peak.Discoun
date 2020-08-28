using Microsoft.EntityFrameworkCore.Migrations;

namespace Peak.Discoun.Migrations
{
    public partial class Add_Name_Pack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Stock",
                table: "Product",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pack",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pack");
        }
    }
}

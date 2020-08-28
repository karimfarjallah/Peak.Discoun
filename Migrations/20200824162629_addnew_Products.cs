using Microsoft.EntityFrameworkCore.Migrations;

namespace Peak.Discoun.Migrations
{
    public partial class addnew_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

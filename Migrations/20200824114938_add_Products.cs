using Microsoft.EntityFrameworkCore.Migrations;

namespace Peak.Discoun.Migrations
{
    public partial class add_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pack",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pack", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_PackId",
                table: "Product",
                column: "PackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Pack_PackId",
                table: "Product",
                column: "PackId",
                principalTable: "Pack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Pack_PackId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Pack");

            migrationBuilder.DropIndex(
                name: "IX_Product_PackId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PackId",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

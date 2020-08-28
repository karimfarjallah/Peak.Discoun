using Microsoft.EntityFrameworkCore.Migrations;

namespace Peak.Discoun.Migrations
{
    public partial class ManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Pack_PackId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_PackId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PackId",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "PackProduct",
                columns: table => new
                {
                    PackId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackProduct", x => new { x.PackId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_PackProduct_Pack_PackId",
                        column: x => x.PackId,
                        principalTable: "Pack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackProduct_ProductId",
                table: "PackProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackProduct");

            migrationBuilder.AddColumn<int>(
                name: "PackId",
                table: "Product",
                type: "int",
                nullable: true);

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
    }
}

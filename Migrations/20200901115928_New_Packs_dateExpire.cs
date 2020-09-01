using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Peak.Discoun.Migrations
{
    public partial class New_Packs_dateExpire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PackProduct");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpire",
                table: "Pack",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateExpire",
                table: "Pack");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PackProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

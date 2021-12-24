using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAcessLibrary.Migrations
{
    public partial class removeImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemImage",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ItemImage",
                table: "Item",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}

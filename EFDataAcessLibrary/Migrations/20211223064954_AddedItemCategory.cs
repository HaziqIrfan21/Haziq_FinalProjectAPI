using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAcessLibrary.Migrations
{
    public partial class AddedItemCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemCategory",
                table: "Item",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCategory",
                table: "Item");
        }
    }
}

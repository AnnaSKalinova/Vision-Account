using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingProgram.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPriceIncVat",
                table: "Items",
                newName: "UnitPriceInclVat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPriceInclVat",
                table: "Items",
                newName: "UnitPriceIncVat");
        }
    }
}

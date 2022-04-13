using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingProgram.Migrations
{
    public partial class SITableisPostedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPosted",
                table: "SalesInvoices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPosted",
                table: "SalesInvoices");
        }
    }
}

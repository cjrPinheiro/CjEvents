using Microsoft.EntityFrameworkCore.Migrations;

namespace CJE.API.Business.Data.Migrations
{
    public partial class attrlocal_place : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Events",
                newName: "Place");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Place",
                table: "Events",
                newName: "Local");
        }
    }
}

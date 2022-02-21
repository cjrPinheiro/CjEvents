using Microsoft.EntityFrameworkCore.Migrations;

namespace CJE.Persistence.Migrations
{
    public partial class DeleteBatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Batch",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Batch",
                table: "Events",
                type: "TEXT",
                nullable: true);
        }
    }
}

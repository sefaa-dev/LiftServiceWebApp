using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftServiceWebApp.Migrations
{
    public partial class techniciannameDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechnicianName",
                table: "Failures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechnicianName",
                table: "Failures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

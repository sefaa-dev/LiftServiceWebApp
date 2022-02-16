using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftServiceWebApp.Migrations
{
    public partial class technicianName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechnicianName",
                table: "Failures",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechnicianName",
                table: "Failures");
        }
    }
}

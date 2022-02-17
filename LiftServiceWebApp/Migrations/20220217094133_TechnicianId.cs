using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftServiceWebApp.Migrations
{
    public partial class TechnicianId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechnicianId",
                table: "Failures",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechnicianId",
                table: "Failures");
        }
    }
}

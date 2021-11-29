using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lighthouse_construction_progress_api.Infrastructure.Persistence.Migrations
{
    public partial class Objects2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionNo",
                table: "LciObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionNo",
                table: "LciObjects");
        }
    }
}

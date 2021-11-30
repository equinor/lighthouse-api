using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equinor.Lighthouse.Api.Infrastructure.Migrations
{
    public partial class readdindexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "LciObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_Id",
                table: "WorkOrders",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LciObjects_Id",
                table: "LciObjects",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Id",
                table: "Activities",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_Id",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_LciObjects_Id",
                table: "LciObjects");

            migrationBuilder.DropIndex(
                name: "IX_Activities_Id",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "LciObjects");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lighthouse_construction_progress_api.Infrastructure.Persistence.Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

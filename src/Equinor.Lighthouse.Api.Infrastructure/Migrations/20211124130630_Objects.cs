using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lighthouse_construction_progress_api.Infrastructure.Persistence.Migrations
{
    public partial class Objects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActionNo",
                table: "LciObjects",
                newName: "WorkOrderName");

            migrationBuilder.AlterColumn<double>(
                name: "RemainingHours",
                table: "LciObjects",
                type: "float",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActivityName",
                table: "LciObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cable_T_Tag",
                table: "LciObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusName",
                table: "LciObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityName",
                table: "LciObjects");

            migrationBuilder.DropColumn(
                name: "Cable_T_Tag",
                table: "LciObjects");

            migrationBuilder.DropColumn(
                name: "StatusName",
                table: "LciObjects");

            migrationBuilder.RenameColumn(
                name: "WorkOrderName",
                table: "LciObjects",
                newName: "ActionNo");

            migrationBuilder.AlterColumn<long>(
                name: "RemainingHours",
                table: "LciObjects",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}

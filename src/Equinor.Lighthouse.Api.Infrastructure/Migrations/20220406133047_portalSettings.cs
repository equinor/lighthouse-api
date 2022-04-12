using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equinor.Lighthouse.Api.Infrastructure.Migrations
{
    public partial class portalSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.CreateTable(
                name: "PortalSettings",
                columns: table => new
                {
                    AzureOid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalSettings", x => x.AzureOid);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AzureOid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppPreset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortalSettingAzureOid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_Favorites_PortalSettings_PortalSettingAzureOid",
                        column: x => x.PortalSettingAzureOid,
                        principalTable: "PortalSettings",
                        principalColumn: "AzureOid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PortalSettingAzureOid",
                table: "Favorites",
                column: "PortalSettingAzureOid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "PortalSettings");

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoursUsed = table.Column<double>(type: "float", nullable: false),
                    Plant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WoNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_Id",
                table: "WorkOrders",
                column: "Id",
                unique: true);
        }
    }
}

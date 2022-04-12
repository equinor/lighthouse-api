using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equinor.Lighthouse.Api.Infrastructure.Migrations
{
    public partial class adjustPortalSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_PortalSettings_PortalSettingAzureOid",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_PortalSettingAzureOid",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "PortalSettingAzureOid",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AzureOid",
                table: "Favorites",
                column: "AzureOid");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_PortalSettings_AzureOid",
                table: "Favorites",
                column: "AzureOid",
                principalTable: "PortalSettings",
                principalColumn: "AzureOid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_PortalSettings_AzureOid",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_AzureOid",
                table: "Favorites");

            migrationBuilder.AddColumn<Guid>(
                name: "PortalSettingAzureOid",
                table: "Favorites",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PortalSettingAzureOid",
                table: "Favorites",
                column: "PortalSettingAzureOid");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_PortalSettings_PortalSettingAzureOid",
                table: "Favorites",
                column: "PortalSettingAzureOid",
                principalTable: "PortalSettings",
                principalColumn: "AzureOid");
        }
    }
}

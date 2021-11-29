using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lighthouse_construction_progress_api.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<long>(type: "bigint", nullable: false),
                    NetId = table.Column<long>(type: "bigint", nullable: false),
                    F10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R1Wbs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R2MainCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R3Discipline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R4MainArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R5SubArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R5Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R6System = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R6Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R7CommPk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R7Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R8ProcurementPack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R8Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R9Phase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R9Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R10SubDiscipline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R10Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R11Responsible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R11Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R12ProjectMilestone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R12Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R13ActivityRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R13Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R14ProjectPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R14Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R15Fav = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R15Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R16Fas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R16Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R17Pau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R17Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R18Module = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R18Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R19SapWbs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R19Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R20Contract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R20Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R21SubSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R21Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R22MaterialAllocationPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R22Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R23ContractorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R23Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R24CostCenterDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R24Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R25McPk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R25Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R26TagTest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R26Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R27SiteLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R27Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R28WorkType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R28Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R29JobDisc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R29Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R30PersonalSortField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R30Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Du = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Es = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnTarget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentProgress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobPackEstimatedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpendedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Esa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPlannedProgress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasePlannedProgress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Besa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rsh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Csh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LciObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkTypeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedQuantity = table.Column<long>(type: "bigint", nullable: true),
                    InstalledQuantity = table.Column<long>(type: "bigint", nullable: true),
                    RemainingHours = table.Column<long>(type: "bigint", nullable: true),
                    PipeTest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    McPkg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComPkg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cable_F_Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cable_F_Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cable_T_Area = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LciObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WoNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: false),
                    HoursUsed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "LciObjects");

            migrationBuilder.DropTable(
                name: "WorkOrders");
        }
    }
}

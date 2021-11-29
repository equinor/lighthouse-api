using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate
{
   public class Activity : PlantEntityBase, IAggregateRoot
{
    public Activity(string plant) : base(plant)
    {
    }

    public string? ActivityNo { get; set; }
    public string? Description { get; set; }
    public long Sequence { get; set; }
    public long NetId { get; set; }
    public string? F10 { get; set; }
    public string? R1Wbs { get; set; }
    public string? R1Description { get; set; }
    public string? R2MainCat { get; set; }
    public string? R2Description { get; set; }
    public string? R3Discipline { get; set; }
    public string? R3Description { get; set; }
    public string? R4MainArea { get; set; }
    public string? R4Description { get; set; }
    public string? R5SubArea { get; set; }
    public string? R5Description { get; set; }
    public string? R6System { get; set; }
    public string? R6Description { get; set; }
    public string? R7CommPk { get; set; }
    public string? R7Description { get; set; }
    public string? R8ProcurementPack { get; set; }
    public string? R8Description { get; set; }
    public string? R9Phase { get; set; }
    public string? R9Description { get; set; }
    public string? R10SubDiscipline { get; set; }
    public string? R10Description { get; set; }
    public string? R11Responsible { get; set; }
    public string? R11Description { get; set; }
    public string? R12ProjectMilestone { get; set; }
    public string? R12Description { get; set; }
    public string? R13ActivityRole { get; set; }
    public string? R13Description { get; set; }
    public string? R14ProjectPhase { get; set; }
    public string? R14Description { get; set; }
    public string? R15Fav { get; set; }
    public string? R15Description { get; set; }
    public string? R16Fas { get; set; }
    public string? R16Description { get; set; }
    public string? R17Pau { get; set; }
    public string? R17Description { get; set; }
    public string? R18Module { get; set; }
    public string? R18Description { get; set; }
    public string? R19SapWbs { get; set; }
    public string? R19Description { get; set; }
    public string? R20Contract { get; set; }
    public string? R20Description { get; set; }
    public string? R21SubSystem { get; set; }
    public string? R21Description { get; set; }
    public string? R22MaterialAllocationPhase { get; set; }
    public string? R22Description { get; set; }
    public string? R23ContractorCode { get; set; }
    public string? R23Description { get; set; }
    public string? R24CostCenterDepartment { get; set; }
    public string? R24Description { get; set; }
    public string? R25McPk { get; set; }
    public string? R25Description { get; set; }
    public string? R26TagTest { get; set; }
    public string? R26Description { get; set; }
    public string? R27SiteLocation { get; set; }
    public string? R27Description { get; set; }
    public string? R28WorkType { get; set; }
    public string? R28Description { get; set; }
    public string? R29JobDisc { get; set; }
    public string? R29Description { get; set; }
    public string? R30PersonalSortField { get; set; }
    public string? R30Description { get; set; }
    public double? Du { get; set; }
    public DateTime? Tse { get; set; }
    public DateTime? Acs { get; set; }
    public DateTime? Es { get; set; }
    public DateTime? Ef { get; set; }
    public DateTime? Ls { get; set; }
    public DateTime? Lf { get; set; }
    public double? OnTarget { get; set; }
    public double? CurrentProgress { get; set; }
    public DateTime? Cancelled { get; set; }
    public double? JobPackEstimatedQuantity { get; set; }
    public double? ExpendedQuantity { get; set; }
    public DateTime? Esa { get; set; }
    public DateTime? CurrentAs { get; set; }
    public DateTime? CurrentAf { get; set; }
    public double? CurrentPlannedProgress { get; set; }
    public double? BasePlannedProgress { get; set; }
    public DateTime? Bes { get; set; }
    public DateTime? Besa { get; set; }
    public DateTime? Bef { get; set; }
    public double? Rsh { get; set; }
    public double? Csh { get; set; }

 
}
}

using System;
namespace Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
public class LciObject : PlantEntityBase
{
    public LciObject(string? plant) : base(plant)
    {
    }
    public string? ObjectNo { get; set; }
    public string? ActivityNo { get; set; }
    public string? ActivityName { get; set; }
    public string? WorkOrderNo { get; set; }
    public string? WorkOrderName { get; set; }
    public string? ActionNo { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public string? StatusName { get; set; }
    public DateTime? StatusDate { get; set; }
    public string? WorkTypeNo { get; set; }
    public string? WorkTypeName { get; set; }
    public double? EstimatedQuantity { get; set; }
    public double? InstalledQuantity { get; set; }
    public double? RemainingHours { get; set; }
    public string? PipeTest { get; set; }
    public string? McPkg { get; set; }
    public string? ComPkg { get; set; }
    public string? Cable_F_Tag { get; set; }
    public string? Cable_F_Area { get; set; }
    public string? Cable_T_Tag { get; set; }
    public string? Cable_T_Area { get; set; }
}

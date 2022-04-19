using System;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;

public class WorkOrder : IAggregateRoot
{

    public string? Plant { get; set; }
    public string? PlantName { get; set; }
    public string? ProjectName { get; set; }
    public string? WoNo { get; set; }
    public string? WoId { get; set; }
    public string? CommPkgNo { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? MileStoneCode { get; set; }
    public string? MilestoneDescription { get; set; }
    public string? MaterialStatusCode { get; set; }
    public string? CategoryCode { get; set; }
    public string? HoldByCode { get; set; }
    public string? DisciplineCode { get; set; }
    public string? DisciplineDescription { get; set; }
    public string? ResponsibleCode { get; set; }
    public string? ResponsibleDescription { get; set; }
    public string? AreaCode { get; set; }
    public string? AreaDescription { get; set; }
    public string? JobStatusCode { get; set; }
    public string? TypeOfWorkCode { get; set; }
    public string? OnShoreOffShoreCode { get; set; }
    public string? WoTypeCode { get; set; }
    public string? ProjectProgress { get; set; }
    public string? ExpendedManHours { get; set; }
    public string? EstimatedManHours { get; set; }
    public string? RemainingManHours { get; set; }
    public string? PlannedStartAtDate { get; set; }
    public string? ActualStartAtDate { get; set; }
    public string? PlannedFinishedAtDate { get; set; }
    public string? ActualFinishedAtDate { get; set; }
    public string? CreatedAt { get; set; }  //TODO? Datetime, but string in db
    public string? LastUpdated { get; set; }
  
}

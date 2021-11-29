using System;


namespace Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;

public class WorkOrder :PlantEntityBase, IAggregateRoot
{
    public WorkOrder() : base(null)
    {
    }

    public WorkOrder(string? plant) : base(plant)
    {
    }

    public string? WoNo  { get; set; }

    public string? ActivityNo { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime? StatusDate { get; set; } 

    public DateTime? EstimatedStartTime { get; set; }

    public DateTime? EstimatedEndTime { get; set; }

    public int Progress { get; set; }

    public long EstimatedHours { get; set; }

    public double HoursUsed   { get; set; }

  
}

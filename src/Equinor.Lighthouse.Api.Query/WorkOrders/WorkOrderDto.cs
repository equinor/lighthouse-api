using System;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Equinor.Lighthouse.Api.Query.Mappings;

namespace Equinor.Lighthouse.Api.Query.WorkOrders;

public class WorkOrderDto : BasePlantDto, IMapFrom<WorkOrder>
{
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

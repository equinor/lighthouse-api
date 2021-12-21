using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Query.Mappings;
using Equinor.Lighthouse.Api.Domain.FAMModels;

namespace Equinor.Lighthouse.Api.Query.McPkg;

public class McPkgDto : IMapFrom<Domain.FAMModels.McPkg>
{

    public string Plant { get; set; }
    public string? ProjectName { get; set; }
    public string? CommPkgNo { get; set; }
    public string? McPkgNo { get; set; }
    public string? Description { get; set; }
    public string? PlantName { get; set; }
    public string? Remark { get; set; }
    public string? ResponsibleCode { get; set; }
    public string? ResponsibleDescription { get; set; }
    public string? AreaCode { get; set; }
    public string? AreaDescription { get; set; }
    public string? Discipline { get; set; }
    //public string? McStatus { get; set; }
    //public List<Milestone> Milestones { get; set; }
    //public List<string?> ProjectNames { get; set; }
    public string? LastUpdated { get; set; }

}

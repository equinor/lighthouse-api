using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;

namespace Equinor.Lighthouse.Api.Test.Common
{
    public class TestDataSet
    {
        public Project Project1 { get; set; }
        public Project Project2 { get; set; }
        public Responsible Responsible1 { get; set; }
        public Responsible Responsible2 { get; set; }
        public Person CurrentUser { get; set; }
    }
}

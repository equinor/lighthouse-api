using System.Collections.Generic;
using System.Linq;

namespace Equinor.Lighthouse.Api.Query.WorkOrders
{
    public class JobStatusCutoff
    {
        public string? Status { get; set; }
        public IEnumerable<string> Weeks { get; set; } = Enumerable.Empty<string>();
    }
}

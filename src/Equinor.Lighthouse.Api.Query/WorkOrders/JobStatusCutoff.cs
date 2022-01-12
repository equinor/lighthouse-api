using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Query.WorkOrders
{
    public class JobStatusCutoff
    {
        public string? Status { get; set; }
        public IEnumerable<string> Weeks { get; set; } = Enumerable.Empty<string>();
    }
}

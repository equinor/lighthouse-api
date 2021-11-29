using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Query;

public class BasePlantDto
{
    public Guid Id { get; set; }
    public string? Plant { get; set; }
}

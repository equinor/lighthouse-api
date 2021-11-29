using System.Collections.Generic;
using System.Diagnostics;

namespace Equinor.Lighthouse.Api.MainApi.Tag;

[DebuggerDisplay("{Items.Count} of {MaxAvailable} available tags")]
public class PCSTagSearchResult
{
    public int MaxAvailable { get; set; }
    public List<PCSTagOverview> Items { get; set; }
}
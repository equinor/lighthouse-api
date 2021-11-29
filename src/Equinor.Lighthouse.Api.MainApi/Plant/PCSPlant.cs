using System.Diagnostics;

namespace Equinor.Lighthouse.Api.MainApi.Plant
{
    [DebuggerDisplay("{Title} {Id} {HasAccess}")]
    public class PCSPlant
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool HasAccess { get; set; }
    }
}

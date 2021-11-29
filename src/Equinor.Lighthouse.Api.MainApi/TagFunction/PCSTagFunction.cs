using System.Diagnostics;

namespace Equinor.Lighthouse.Api.MainApi.TagFunction;

[DebuggerDisplay("{Code}/{RegisterCode}")]
public class PCSTagFunction
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string RegisterCode { get; set; }
}
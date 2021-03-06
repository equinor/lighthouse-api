using System.Diagnostics;

namespace Equinor.Lighthouse.Api.MainApi.Tag;

[DebuggerDisplay("{TagNo}")]
public class PCSTagOverview
{
    public long Id { get; set; }
    public string CommPkgNo { get; set; }
    public string Description { get; set; }
    public string McPkgNo { get; set; }
    public string PurchaseOrderTitle { get; set; }
    public string RegisterCode { get; set; }
    public string TagFunctionCode { get; set; }
    public string TagNo { get; set; }
    public string MccrResponsibleCodes { get; set; } }
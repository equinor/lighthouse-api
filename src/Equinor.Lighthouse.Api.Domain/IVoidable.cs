namespace Equinor.Lighthouse.Api.Domain
{
    public interface IVoidable
    {
        bool IsVoided { get; set; }
    }
}

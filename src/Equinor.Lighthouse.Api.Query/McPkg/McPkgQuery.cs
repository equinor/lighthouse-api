using MediatR;

namespace Equinor.Lighthouse.Api.Query.McPkg;

public class McPkgQuery : IRequest<PaginatedList<McPkgDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 0;
}

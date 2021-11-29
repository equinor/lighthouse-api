using System.Collections.Generic;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.ResponsibleAggregate
{
    public class GetAllResponsiblesQuery : IRequest<Result<IEnumerable<ResponsibleDto>>>
    {
    }
}

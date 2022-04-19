using System;
using System.Collections.Generic;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.Favorites;

public class GetFavoriteIdsByAzureOidQuery : IRequest<Result<ICollection<Guid>>>
{
    public Guid AzureOid { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.FavoriteAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.Favorites;

public class GetFavoriteIdsByAzureOidQueryHandler : IRequestHandler<GetFavoriteIdsByAzureOidQuery, Result<ICollection<Guid>>>
{
    private readonly IReadOnlyContext _context;

    public GetFavoriteIdsByAzureOidQueryHandler(IReadOnlyContext context) => _context = context;

    public async Task<Result<ICollection<Guid>>> Handle(GetFavoriteIdsByAzureOidQuery request, CancellationToken cancellationToken)
    {
        var favorites = await _context.QuerySet<Favorite>().Where(ps => ps.AzureOid == request.AzureOid)
            .Select(f => f.FavoriteId)
            .ToListAsync(cancellationToken);
            
        if (favorites.Count == 0)
        { 
            return new NotFoundResult<ICollection<Guid>>(Strings.EntityNotFound(nameof(Favorite), request.AzureOid));
        }

        return new SuccessResult<ICollection<Guid>>(favorites);
    }
}

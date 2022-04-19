using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.FavoriteAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.Favorites;

public class GetFavoriteQueryHandler : IRequestHandler<GetFavoriteQuery, Result<FavoriteDto>>
{
    private readonly IReadOnlyContext _context;

    public GetFavoriteQueryHandler(IReadOnlyContext context) => _context = context;

    public async Task<Result<FavoriteDto>> Handle(GetFavoriteQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QuerySet<Favorite>().Where(ps => ps.FavoriteId == request.FavoriteId)
            .SingleOrDefaultAsync(cancellationToken);

        if (result == null)
        {
            return new NotFoundResult<FavoriteDto>(Strings.EntityNotFound(nameof(Domain.AggregateModels.FavoriteAggregate.Favorite), request.FavoriteId));
        }

        return new SuccessResult<FavoriteDto>(new FavoriteDto
        {
            FavoriteId = result.FavoriteId,
            AppId = result.AppId,
            AzureOid = result.AzureOid,
            AppPreset = result.AppPreset,
            FavoriteName = result.FavoriteName
        });
    }
}

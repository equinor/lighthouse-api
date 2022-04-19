using System;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.FavoriteAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using Equinor.Lighthouse.Api.Infrastructure;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.FavoriteCommands.CreateFavorite;

public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand, Result<Guid>>
{
    private readonly IWriteContext _context;

    public CreateFavoriteCommandHandler(IWriteContext context) => _context = context;

    public async Task<Result<Guid>> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
    {

       var favorite = _context.Set<Favorite>().Add(new Favorite
        {
            AzureOid = request.AzureOid,
            AppId = request.AppId,
            AppPreset = request.AppPreset,
            FavoriteName = request.FavoriteName
        });

       await _context.SaveChangesAsync(cancellationToken);

       return new SuccessResult<Guid>(favorite.Entity.FavoriteId);
    }
}

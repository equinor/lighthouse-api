using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate.Favorite;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.FavoriteCommands.CreateFavorite;

public class CreateFavoriteCommand : IRequest<Result<FavoriteDto>>
{
    public FavoriteDto Favorite { get; }
    public CreateFavoriteCommand(FavoriteDto dto) => Favorite = dto;
}

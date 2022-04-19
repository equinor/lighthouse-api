using System;
using Equinor.Lighthouse.Api.Domain.AggregateModels.FavoriteAggregate;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.Favorites
{
    public class GetFavoriteQuery : IRequest<Result<FavoriteDto>>
    {
        public Guid FavoriteId { get; set; }
    }
}

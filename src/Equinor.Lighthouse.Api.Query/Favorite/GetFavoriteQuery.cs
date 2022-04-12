using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate.Favorite;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.Favorite
{
    public class GetFavoriteQuery : IRequest<Result<FavoriteDto>>
    {
        public Guid FavoriteId { get; set; }
    }
}

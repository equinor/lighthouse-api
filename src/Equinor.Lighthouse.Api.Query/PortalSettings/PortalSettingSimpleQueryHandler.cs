using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.PortalSettings;

public class PortalSettingSimpleQueryHandler : IRequestHandler<GetSimplePortalSettingQuery, Result<PortalSettingSimpleDto>>
{

    private readonly IReadOnlyContext _context;

    public PortalSettingSimpleQueryHandler(IReadOnlyContext context) => _context = context;

    public async Task<Result<PortalSettingSimpleDto>> Handle(GetSimplePortalSettingQuery request, CancellationToken cancellationToken)
    {
        var portalSetting = await _context.QuerySet<PortalSetting>().Where(ps => ps.AzureOid == request.AzureOid)
            .SingleOrDefaultAsync(cancellationToken);
            
        if (portalSetting == null)
        { 
            return new NotFoundResult<PortalSettingSimpleDto>(Strings.EntityNotFound(nameof(PortalSetting), request.AzureOid));
        }

        var simpleDto = new PortalSettingSimpleDto
        {
            AzureOid = portalSetting.AzureOid,
            FavoriteIds = portalSetting.Favorites.Select(f => f.FavoriteId).ToList()
        };

        return new SuccessResult<PortalSettingSimpleDto>(simpleDto);
    }
}

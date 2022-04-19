//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Equinor.Lighthouse.Api.Domain;
//using Equinor.Lighthouse.Api.Domain.AggregateModels.FavoriteAggregate;
//using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using ServiceResult;

//namespace Equinor.Lighthouse.Api.Query.PortalSettings;

//public class PortalSettingQueryHandler : IRequestHandler<GetPortalSettingQuery, Result<PortalSettingDto>>
//{

//    private readonly IReadOnlyContext _context;

//    public PortalSettingQueryHandler(IReadOnlyContext context) => _context = context;

//    public async Task<Result<PortalSettingDto>> Handle(GetPortalSettingQuery request, CancellationToken cancellationToken)
//    {
//        var portalSetting = await _context.QuerySet<Favorite>().Where(f => f.AzureOid == request.AzureOid)
//            .SingleOrDefaultAsync(cancellationToken);
            
//        if (portalSetting == null)
//        {
//            return new NotFoundResult<PortalSettingDto>(Strings.EntityNotFound(nameof(PortalSetting), request.AzureOid));
//        }

//        var simpleDto = new PortalSettingDto
//        {
//            AzureOid = portalSetting.AzureOid,
//            Favorites = portalSetting.Favorites};

//        return new SuccessResult<PortalSettingDto>(simpleDto);
//    }
//}

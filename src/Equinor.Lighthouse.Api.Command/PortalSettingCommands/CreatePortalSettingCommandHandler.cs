using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain.AggregateModels.FavoriteAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using Equinor.Lighthouse.Api.Infrastructure;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.PortalSettingCommands;

public class CreatePortalSettingCommandHandler : IRequestHandler<CreatePortalSettingCommand, Result<PortalSettingDto>>
{
    private readonly IWriteContext _context;

    public CreatePortalSettingCommandHandler(IWriteContext context) 
        => _context = context;


    public async Task<Result<PortalSettingDto>> Handle(CreatePortalSettingCommand request,
        CancellationToken cancellationToken)
    {
        var result =_context.Set<PortalSetting>().Add(new PortalSetting
        {
            AzureOid = request.AzureOid,
            Favorites = new List<Favorite>()
        });

        await _context.SaveChangesAsync(cancellationToken);
        

        return new SuccessResult<PortalSettingDto>(new PortalSettingDto
        {
            AzureOid = result.Entity.AzureOid
        }); 
    }
}

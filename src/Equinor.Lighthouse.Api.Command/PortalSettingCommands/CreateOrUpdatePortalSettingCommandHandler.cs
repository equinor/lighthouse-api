using System;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.PersonCommands.CreateSavedFilter;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.PortalSettingCommands;

public class CreateOrUpdatePortalSettingCommandHandler : IRequestHandler<CreateOrUpdatePortalSettingCommand, Result<Guid>>
{

    public CreateOrUpdatePortalSettingCommandHandler()
    {
        
    }


    public async Task<Result<Guid>> Handle(CreateOrUpdatePortalSettingCommand request,
        CancellationToken cancellationToken)
    {





        return new SuccessResult<Guid>(new Guid()); //TODO
    }
}

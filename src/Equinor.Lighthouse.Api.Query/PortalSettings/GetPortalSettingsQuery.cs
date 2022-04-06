using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Equinor.Lighthouse.Api.Query.PortalSettings;

public class GetPortalSettingsQuery : IRequest<PaginatedList<PortalSettingSimpleDto>>
{
}

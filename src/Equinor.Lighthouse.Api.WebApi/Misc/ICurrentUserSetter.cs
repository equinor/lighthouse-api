using System;

namespace Equinor.Lighthouse.Api.WebApi.Misc;

public interface ICurrentUserSetter
{
    void SetCurrentUserOid(Guid oid);
}
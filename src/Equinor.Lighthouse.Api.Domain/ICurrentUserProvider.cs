using System;

namespace Equinor.Lighthouse.Api.Domain;

public interface ICurrentUserProvider
{
    Guid GetCurrentUserOid();
    bool HasCurrentUser();
}
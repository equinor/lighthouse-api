using System;

namespace Equinor.Lighthouse.Api.Domain.Time
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
    }
}

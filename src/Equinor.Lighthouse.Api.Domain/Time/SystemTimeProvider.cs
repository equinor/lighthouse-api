using System;

namespace Equinor.Lighthouse.Api.Domain.Time
{
    public class SystemTimeProvider : ITimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}

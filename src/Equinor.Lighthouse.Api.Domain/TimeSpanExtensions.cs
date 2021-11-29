using System;

namespace Equinor.Lighthouse.Api.Domain
{
    public static class TimeSpanExtensions
    {
        public static int Weeks(this TimeSpan span) => span.Days / 7;
    }
}

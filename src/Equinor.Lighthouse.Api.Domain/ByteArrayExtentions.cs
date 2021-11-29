using System;

namespace Equinor.Lighthouse.Api.Domain;

public static class ByteArrayExtensions
{
    public static string ConvertToString(this byte[] bytes) => Convert.ToBase64String(bytes);
}
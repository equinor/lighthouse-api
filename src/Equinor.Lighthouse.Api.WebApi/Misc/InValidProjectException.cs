using System;

namespace Equinor.Lighthouse.Api.WebApi.Misc;

public class InValidProjectException : Exception
{
    public InValidProjectException(string error) : base(error)
    {
    }
}
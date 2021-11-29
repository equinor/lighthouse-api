using System;

namespace Equinor.Lighthouse.Api.MainApi.Exceptions
{
    public class InvalidResultException : Exception
    {
        public InvalidResultException(string message) : base(message)
        {
        }
    }
}

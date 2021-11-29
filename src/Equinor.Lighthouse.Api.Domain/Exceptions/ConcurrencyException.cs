﻿using System;

namespace Equinor.Lighthouse.Api.Domain.Exceptions;

public class ConcurrencyException : Exception
{
    public ConcurrencyException(string message) : base(message)
    {
    }

    public ConcurrencyException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
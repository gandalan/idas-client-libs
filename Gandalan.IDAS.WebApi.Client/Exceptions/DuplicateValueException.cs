using System;

namespace Gandalan.IDAS.WebApi.Data.Exceptions;

public class DuplicateValueException : Exception
{
    public DuplicateValueException(string message) : base(message)
    {
    }
}

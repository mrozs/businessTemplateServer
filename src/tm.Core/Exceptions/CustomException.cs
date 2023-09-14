using System;

namespace tm.Core.Exceptions;

public abstract class CustomException: Exception
{
    public CustomException(string message) : base(message)
    {

    }
}

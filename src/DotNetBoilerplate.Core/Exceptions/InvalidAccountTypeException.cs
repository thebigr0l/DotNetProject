using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Exceptions;

public class InvalidAccountTypeException : CustomException
{
    public InvalidAccountTypeException(string value) : base($"{value} is not a valid account type.")
    {
    }
}
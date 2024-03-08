using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Exceptions;

public sealed class InvalidEmailException : CustomException
{
    public InvalidEmailException(string emailValue) : base($"{emailValue} is not a valid email.")
    {
    }
}
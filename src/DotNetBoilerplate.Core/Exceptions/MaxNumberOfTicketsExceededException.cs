using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Exceptions;

public class MaxNumberOfTicketsExceededException() : CustomException("Max number of tickets exceeded.");
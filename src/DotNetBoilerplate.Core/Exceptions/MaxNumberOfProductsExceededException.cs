using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Exceptions;

public class MaxNumberOfProductsExceededException() : CustomException("Max number of products exceeded.");
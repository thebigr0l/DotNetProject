using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Exceptions;

internal sealed class ProductNotFound() : CustomException("Product not found");
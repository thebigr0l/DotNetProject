using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Exceptions;

internal sealed class AllProductsAreNotBoughtOrBoughtException() : CustomException("All products are not bought or bought");
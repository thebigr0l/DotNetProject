using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Entities.ShoppingLists;

public class UserHasShoppingListWithSameShoppingDateException() : CustomException("User has shopping list with same shopping date");
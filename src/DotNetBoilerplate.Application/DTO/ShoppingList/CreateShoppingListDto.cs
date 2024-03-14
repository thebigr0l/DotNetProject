namespace DotNetBoilerplate.Application.DTO.ShoppingList;

public record CreateShoppingListDto(
    string Name,
    DateTimeOffset ShoppingDate);
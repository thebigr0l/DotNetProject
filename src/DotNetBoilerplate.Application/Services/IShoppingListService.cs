using DotNetBoilerplate.Application.DTO.ShoppingList;

namespace DotNetBoilerplate.Application.Services;

public interface IShoppingListService
{
    Task CreateAsync(CreateShoppingListDto dto);
    Task AddProductAsync(Guid shoppingListId, AddProductDto dto);
}
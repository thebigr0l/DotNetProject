using DotNetBoilerplate.Application.DTO.ShoppingList;
using DotNetBoilerplate.Application.Exceptions;
using DotNetBoilerplate.Core.Entities.ShoppingLists;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;

namespace DotNetBoilerplate.Application.Services;

internal sealed class ShoppingListService(
    IContext context,
    IShoppingListRepository repository,
    IClock clock)
    : IShoppingListService
{
    public async Task CreateAsync(CreateShoppingListDto dto)
    {
        var hasShoppingListWithSameShoppingDate = await repository
            .ExistsForUserByShoppingDateAsync(context.Identity.Id, dto.ShoppingDate);

        var shoppingList = ShoppingList.Create(
            context.Identity.Id,
            clock.DateTimeOffsetNow(),
            dto.Name,
            dto.ShoppingDate,
            hasShoppingListWithSameShoppingDate);

        await repository.AddAsync(shoppingList);
    }

    public async Task AddProductAsync(Guid shoppingListId, AddProductDto dto)
    {
        var shoppingList = await repository.GetAsync(shoppingListId);

        if (shoppingList is null || shoppingList.UserId != context.Identity.Id)
            throw new ShoppingListNotFoundException(shoppingListId);

        var product = Product.Create(dto.Name, dto.Quantity, Money.Create(dto.Currency, dto.Amount));

        shoppingList.AddProduct(product);

        await repository.UpdateAsync(shoppingList);
    }
}
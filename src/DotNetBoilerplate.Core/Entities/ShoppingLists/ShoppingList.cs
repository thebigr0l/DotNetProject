using DotNetBoilerplate.Core.Exceptions;

namespace DotNetBoilerplate.Core.Entities.ShoppingLists;

public class ShoppingList
{
    public Guid Id { get; private init; }
    public Guid UserId { get; private init; }
    public DateTimeOffset CreatedAt { get; private init; }
    public string Name { get; private set; }
    public DateTimeOffset ShoppingDate { get; private init; }
    private List<Product> Products { get; set; }

    public DateTimeOffset? FinishedAt { get; private set; }

    private const int MaxNumberOfProducts = 20;

    private ShoppingList() { }

    public static ShoppingList Create(
        Guid userId,
        DateTimeOffset createdAt,
        string name,
        DateTimeOffset shoppingDate,
        bool userHasShoppingListWithSameShoppingDate
        )
    {
        if (userHasShoppingListWithSameShoppingDate)
            throw new UserHasShoppingListWithSameShoppingDateException();

        var shoppingList = new ShoppingList
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CreatedAt = createdAt,
            Name = name,
            ShoppingDate = shoppingDate,
            Products = []
        };
        
        return shoppingList;
    }
    
    public void AddProduct(Product product)
    {
        if (Products.Count >= MaxNumberOfProducts)
            throw new MaxNumberOfProductsExceededException();

        Products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        var productExists = Products.Any(p => p.Id == product.Id);

        if (!productExists)
            throw new ProductNotFound();

        Products.Remove(product);
    }

    public void MarkProductAsBought(Product product)
    {
        var productExists = Products.Any(p => p.Id == product.Id);

        if (!productExists)
            throw new ProductNotFound();

        product.MarkAsBought();
    }

    public void MarkProductAsNotBought(Product product)
    {
        var productExists = Products.Any(p => p.Id == product.Id);

        if (!productExists)
            throw new ProductNotFound();

        product.MarkAsNotBought();
    }
    public void Finish(DateTimeOffset now)
    {
        var allProductsAreBoughtOrNotBought = Products
            .All(p => p.Status is ProductStatus.Bought or ProductStatus.NotBought);
        if (!allProductsAreBoughtOrNotBought)
            throw new AllProductsAreNotBoughtOrBoughtException();

        FinishedAt = now;
    }
}
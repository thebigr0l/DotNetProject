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

    private const int MaxNumberOfProducts = 20;

    private ShoppingList() {}

    public ShoppingList Create(
        Guid userId, 
        DateTimeOffset createdAt, 
        string name, 
        DateTimeOffset shoppingDate)
    {
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
}
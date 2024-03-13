﻿namespace DotNetBoilerplate.Core.Entities.ShoppingLists;

public class Product
{
    public Guid Id { get; private init; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public ProductStatus Status { get; private set; }
    public Money Price { get; private set; }
    
    private Product() {}
    
    public Product Create(string name, int quantity, Money price)
    {
        
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Quantity = quantity,
            Status = ProductStatus.Draft,
            Price = price
        };
        
        return product;
    }
    
    public void MarkAsBought()
    {
        Status = ProductStatus.Bought;
    }
}

public enum ProductStatus
{
    Draft,
    Bought,
    NotBought
}
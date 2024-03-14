namespace DotNetBoilerplate.Application.DTO.ShoppingList;

public record AddProductDto(string Name, int Quantity, string Currency, int Amount);
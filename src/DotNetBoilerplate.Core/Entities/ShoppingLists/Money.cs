namespace DotNetBoilerplate.Core.Entities.ShoppingLists;

public class Money
{
    private static readonly List<string> Currencies =  [ "USD", "EUR", "GBP", "PLN" ];
    public string Currency { get; private set; }
    public int Amount { get; private set; }
    
    private Money() {}
    
    public static Money Create(string currency, int amount)
    {
        if (!Currencies.Contains(currency))
        {
            throw new ArgumentException("Invalid currency");
        }
        
        if (amount <= 0) 
        {
            throw new ArgumentException("Amount must be greater than 0");
        }
        
        var money = new Money
        {
            Currency = currency,
            Amount = amount
        };
        
        return money;
    }
}
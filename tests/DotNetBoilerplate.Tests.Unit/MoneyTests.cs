using DotNetBoilerplate.Core.Entities.ShoppingLists;
using Shouldly;
using Xunit;

namespace DotNetBoilerplate.Tests.Unit;

public class MoneyTests
{
    [Fact]
    public void  GivenInvalidCurrency_CreateMoney_ShouldThrowAnException ()
    {
        // Arrange
        const string currency = "INVALID";
        const int amount = 100;
        
        // Act
        Action act = () => Money.Create(currency, amount);
        
        // Assert
        act.ShouldThrow(typeof(ArgumentException));
    }
    
    //Todo - test for amount <= 0, test for valid currency, test for amount > 0
    
    [Fact]
    public void GivenAmountIsLessThan1_CreateMoney_ShouldThrowAnException()
    {
        // Arrange
        const string currency = "USD";
        const int amount = -100;
        
        // Act
        Action act = () => Money.Create(currency, amount);
        
        // Assert
        act.ShouldThrow(typeof(ArgumentException));
    }
    
    [Fact]
    public void GivenValidCurrencyAndAmount_CreateMoney_ShouldReturnMoney()
    {
        // Arrange
        const string currency = "USD";
        const int amount = 100;
        
        // Act
        var money = Money.Create(currency, amount);
        
        // Assert
        money.Currency.ShouldBe(currency);
        money.Amount.ShouldBe(amount);
    }
    
    [Fact]
    public void GivenAmountIsGreaterThan0_CreateMoney_ShouldReturnMoney()
    {
        // Arrange
        const string currency = "USD";
        const int amount = 100;
        
        // Act
        var money = Money.Create(currency, amount);
        
        // Assert
        money.Currency.ShouldBe(currency);
        money.Amount.ShouldBe(amount);
    }
}
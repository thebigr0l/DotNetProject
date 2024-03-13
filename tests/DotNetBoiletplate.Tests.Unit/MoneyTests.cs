﻿using DotNetBoilerplate.Core.Entities.ShoppingLists;
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
}
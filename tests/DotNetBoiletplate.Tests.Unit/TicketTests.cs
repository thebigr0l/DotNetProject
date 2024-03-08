using DotNetBoilerplate.Core.Entities.Tickets;
using DotNetBoilerplate.Core.Entities.Users;
using DotNetBoilerplate.Core.Exceptions;
using Shouldly;
using Xunit;

namespace DotNetBoilerplate.Tests.Unit;

public class TicketTests
{
    [Fact]
    public void
        Create_WhenUserTicketsCountIsGreaterThanMaxNumberOfTickets_ShouldThrowMaxNumberOfTicketsExceededException()
    {
        // Arrange
        var user = User.New(Guid.NewGuid(), "emai@t.pl", "dfsfsdf", "sdfdsfds", DateTime.Now);
        var userTicketsCount = 5;
        var now = DateTimeOffset.Now;

        // Act
        Action act = () => Ticket.Create(user, userTicketsCount, now);

        Should.Throw<MaxNumberOfTicketsExceededException>(act);
    }

    [Fact]
    public void
        Create_WhenUserTicketsCountIsLessThanMaxNumberOfTickets_ShouldSucceed()
    {
        // Arrange
        var user = User.New(Guid.NewGuid(), "emai@t.pl", "dfsfsdf", "sdfdsfds", DateTime.Now);
        var userTicketsCount = 4;
        var now = DateTimeOffset.Now;

        // Act
        var ticket = Ticket.Create(user, userTicketsCount, now);

        ticket.ShouldNotBe(null);
    }
}
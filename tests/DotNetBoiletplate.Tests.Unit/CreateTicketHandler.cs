using DotNetBoilerplate.Application.Commands.Tickets.Create;
using DotNetBoilerplate.Core.Repositories;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shouldly;
using Xunit;

namespace DotNetBoilerplate.Tests.Unit;

public class CreateTicketHandlerTests
{
    private readonly IClock _clock = Substitute.For<IClock>();
    private readonly IContext _context = Substitute.For<IContext>();
    private readonly ITicketRepository _ticketRepository = Substitute.For<ITicketRepository>();
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();

    [Fact]
    public async Task HandleAsync_WhenUserIsNull_ThrowsUserNotFoundException()
    {
        // Arrange
        var sut = new CreateTicketHandler(
            _context,
            _ticketRepository,
            _userRepository,
            _clock
        );

        _context.Identity.Id.Returns(Guid.NewGuid());
        _userRepository.FindByIdAsync(_context.Identity.Id).ReturnsNull();

        // Act
        var exception = await Record.ExceptionAsync(() => sut.HandleAsync(new CreateTicket()));

        // Assert
        exception.ShouldNotBeNull();
    }
}
using DotNetBoilerplate.Core.Entities.Users;
using DotNetBoilerplate.Core.Exceptions;
using DotNetBoilerplate.Core.ValueObjects;
using DotNetBoilerplate.Shared.Abstractions.Domain;

namespace DotNetBoilerplate.Core.Entities.Tickets;

public class Ticket : Entity
{
    private const int MaxNumberOfTickets = 5;

    private Ticket()
    {
    }

    public Guid Id { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; } = null!;

    public static Ticket Create(User user, int userTicketsCount, DateTimeOffset now)
    {
        if (userTicketsCount >= MaxNumberOfTickets)
            throw new MaxNumberOfTicketsExceededException();

        if (now == new DateTimeOffset(2024, 1, 1, 1, 1, 1, TimeSpan.Zero))
            throw new InvalidTicketCreatedAtDateException();

        return new Ticket
        {
            Id = Guid.NewGuid(),
            User = user,
            CreatedAt = now,
            UserId = user.Id
        };
    }
}
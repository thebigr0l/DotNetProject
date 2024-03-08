using DotNetBoilerplate.Application.Exceptions;
using DotNetBoilerplate.Core.Entities.Tickets;
using DotNetBoilerplate.Core.Repositories;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;

namespace DotNetBoilerplate.Application.Commands.Tickets.Create;

public class CreateTicketHandler(
    IContext context,
    ITicketRepository ticketRepository,
    IUserRepository userRepository,
    IClock clock
) : ICommandHandler<CreateTicket>
{
    public async Task HandleAsync(CreateTicket command)
    {
        var user = await userRepository.FindByIdAsync(context.Identity.Id);

        if (user is null) throw new UserNotFoundException(context.Identity.Id);

        var userTicketsCount = await ticketRepository.CountByUserIdAsync(context.Identity.Id);

        var ticket = Ticket.Create(user, userTicketsCount, clock.DateTimeOffsetNow());

        await ticketRepository.AddAsync(ticket);
    }
}
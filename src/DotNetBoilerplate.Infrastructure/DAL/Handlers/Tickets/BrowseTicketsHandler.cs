using DotNetBoilerplate.Application.DTO;
using DotNetBoilerplate.Application.Queries.Tickets;
using DotNetBoilerplate.Core.Repositories;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Infrastructure.DAL.Handlers.Tickets;

public class BrowseTicketsHandler(
    IContext context,
    ITicketRepository ticketRepository
) : IQueryHandler<BrowseTickets, IEnumerable<TicketDto>>
{
    public async Task<IEnumerable<TicketDto>> HandleAsync(BrowseTickets query)
    {
        var tickets = await ticketRepository.GetAllByUserId(context.Identity.Id);

        return tickets.Select(x => new TicketDto(x.Id, x.CreatedAt));
    }
}
using DotNetBoilerplate.Core.Entities.Tickets;
using DotNetBoilerplate.Core.Repositories;
using DotNetBoilerplate.Core.ValueObjects;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class InMemoryTicketRepository : ITicketRepository
{
    private readonly List<Ticket> _tickets = [];

    public Task AddAsync(Ticket ticket)
    {
        _tickets.Add(ticket);
        return Task.CompletedTask;
    }

    public Task<int> CountByUserIdAsync(UserId userId)
    {
        return Task.FromResult(_tickets.Count(x => x.UserId == userId));
    }

    public Task<IEnumerable<Ticket>> GetAllByUserId(UserId userId)
    {
        return Task.FromResult(_tickets.Where(x => x.UserId == userId));
    }
}
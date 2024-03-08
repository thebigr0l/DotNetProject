using DotNetBoilerplate.Core.Entities.Tickets;
using DotNetBoilerplate.Core.ValueObjects;

namespace DotNetBoilerplate.Core.Repositories;

public interface ITicketRepository
{
    Task AddAsync(Ticket ticket);
    Task<int> CountByUserIdAsync(UserId userId);
    Task<IEnumerable<Ticket>> GetAllByUserId(UserId userId);
}
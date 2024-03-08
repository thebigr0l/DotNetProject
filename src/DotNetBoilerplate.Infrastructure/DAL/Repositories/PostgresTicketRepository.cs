using DotNetBoilerplate.Core.Entities.Tickets;
using DotNetBoilerplate.Core.Repositories;
using DotNetBoilerplate.Core.ValueObjects;
using DotNetBoilerplate.Infrastructure.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class PostgresTicketRepository(
    DotNetBoilerplateWriteDbContext dbContext
) : ITicketRepository
{
    public async Task AddAsync(Ticket ticket)
    {
        await dbContext.Tickets.AddAsync(ticket);
    }

    public async Task<IEnumerable<Ticket>> GetAllByUserId(UserId userId)
    {
        return await dbContext.Tickets
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<int> CountByUserIdAsync(UserId userId)
    {
        return await dbContext.Tickets
            .Where(x => x.UserId == userId)
            .CountAsync();
    }
}
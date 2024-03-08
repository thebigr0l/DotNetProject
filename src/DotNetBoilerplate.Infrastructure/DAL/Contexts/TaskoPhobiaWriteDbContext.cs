using DotNetBoilerplate.Core.Entities.Tickets;
using DotNetBoilerplate.Core.Entities.Users;
using DotNetBoilerplate.Infrastructure.DAL.Configurations.Write;
using DotNetBoilerplate.Shared.Abstractions.Outbox;
using Microsoft.EntityFrameworkCore;

namespace DotNetBoilerplate.Infrastructure.DAL.Contexts;

internal sealed class DotNetBoilerplateWriteDbContext(DbContextOptions<DotNetBoilerplateWriteDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dotNetBoilerplate");

        modelBuilder.ApplyConfiguration(new UserWriteConfiguration());
        modelBuilder.ApplyConfiguration(new OutboxMessageWriteConfiguration());
        modelBuilder.ApplyConfiguration(new TicketWriteConfiguration());
    }
}
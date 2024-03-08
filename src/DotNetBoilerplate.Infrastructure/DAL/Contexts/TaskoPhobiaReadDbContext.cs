using DotNetBoilerplate.Infrastructure.DAL.Configurations.Read;
using DotNetBoilerplate.Infrastructure.DAL.Configurations.Read.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetBoilerplate.Infrastructure.DAL.Contexts;

internal sealed class DotNetBoilerplateReadDbContext : DbContext
{
    public DotNetBoilerplateReadDbContext(DbContextOptions<DotNetBoilerplateReadDbContext> options) : base(options)
    {
    }

    public DbSet<UserReadModel> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dotNetBoilerplate");
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserReadConfiguration());
    }
}
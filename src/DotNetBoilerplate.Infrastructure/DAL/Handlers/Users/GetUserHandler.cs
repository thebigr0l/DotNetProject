using Dapper;
using DotNetBoilerplate.Application.DTO;
using DotNetBoilerplate.Application.Queries.Users;
using DotNetBoilerplate.Infrastructure.DAL.Configurations.Read.Model;
using DotNetBoilerplate.Infrastructure.DAL.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;

namespace DotNetBoilerplate.Infrastructure.DAL.Handlers.Users;

internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDetailsDto>
{
    private readonly IContext _context;
    private readonly PostgresOptions _postgresOptions;
    private readonly DbSet<UserReadModel> _users;

    public GetUserHandler(DotNetBoilerplateReadDbContext dbContext, IContext context,
        IOptions<PostgresOptions> postgresOptions)
    {
        _context = context;
        _postgresOptions = postgresOptions.Value;
        _users = dbContext.Users;
    }

    public async Task<UserDetailsDto> HandleAsync(GetUser query)
    {
        await using var connection = new NpgsqlConnection(_postgresOptions.ConnectionString);

        return await connection.QuerySingleOrDefaultAsync<UserDetailsDto>(
            @"SELECT *
                FROM  ""dotNetBoilerplate"".""Users""
                WHERE ""Id"" = @Id",
            new { _context.Identity.Id });
    }
}
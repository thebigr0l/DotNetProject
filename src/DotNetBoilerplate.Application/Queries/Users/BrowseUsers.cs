using DotNetBoilerplate.Application.DTO;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Queries.Users;

public class BrowseUsers : PagedQuery<UserDetailsDto>
{
    public string Username { get; set; }
}
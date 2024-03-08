using DotNetBoilerplate.Application.DTO;
using DotNetBoilerplate.Infrastructure.DAL.Configurations.Read.Model;

namespace DotNetBoilerplate.Infrastructure.DAL.Handlers;

internal static class Extensions
{
    public static UserDetailsDto AsUserDetailsDto(this UserReadModel user)
    {
        return new UserDetailsDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        };
    }

    private static UserDto AsDto(this UserReadModel user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username
        };
    }
}
using DotNetBoilerplate.Core.Entities.Users;
using DotNetBoilerplate.Core.ValueObjects;

namespace DotNetBoilerplate.Core.Services;

public interface IUserReadService
{
    Task<bool> ExistsByEmailAsync(Email email);
    Task<bool> ExistsByUsernameAsync(Username username);
    Task<User> GetByEmailAsync(Email email);
    Task<bool> ExistsByIdAsync(UserId id);
}
using DotNetBoilerplate.Core.Entities.Users;
using DotNetBoilerplate.Core.ValueObjects;

namespace DotNetBoilerplate.Core.Repositories;

public interface IUserRepository
{
    Task<User> FindByIdAsync(UserId id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}
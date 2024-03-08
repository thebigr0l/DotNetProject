using DotNetBoilerplate.Application.DTO;

namespace DotNetBoilerplate.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}
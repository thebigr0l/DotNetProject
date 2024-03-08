using DotNetBoilerplate.Application.DTO;

namespace DotNetBoilerplate.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}
using tm.Application.DTO;

namespace tm.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDTO jwt);
    JwtDTO Get();
}
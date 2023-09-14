using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tm.Application.DTO;

namespace tm.Application.Security;

public interface IAuthenticator
{
    JwtDTO CreateToken(Guid userId, string role);
}

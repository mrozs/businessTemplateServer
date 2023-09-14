using tm.Application.Abstractions;
using tm.Application.DTO;

namespace tm.Application.Queries;

public class GetUsers : IQuery<IEnumerable<UserDTO>>
{
}
using tm.Application.Abstractions;
using tm.Application.DTO;

namespace tm.Application.Queries;

public class GetUser : IQuery<UserDTO>
{
    public Guid UserId { get; set; }
}

using tm.Core.Entities;
using tm.Core.ValueObjects;

namespace tm.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(UserId id);
    Task<User> GetByEmailAsync(Email email);
    Task<User> GetByUsernameAsync(UserName username);
    Task AddAsync(User user);
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tm.Core.Entities;
using tm.Core.Repositories;
using tm.Core.ValueObjects;

namespace tm.Tests.Integration;

internal sealed class TestUserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public async Task<User> GetByIdAsync(UserId id)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(x => x.Id == id);
    }

    public async Task<User> GetByEmailAsync(Email email)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(x => x.Email == email);
    }

    public async Task<User> GetByUsernameAsync(UserName username)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(x => x.UserName == username);
    }

    public async Task AddAsync(User user)
    {
        _users.Add(user);
        await Task.CompletedTask;
    }
}
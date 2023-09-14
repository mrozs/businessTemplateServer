using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tm.Core.Entities;
using tm.Core.Repositories;
using tm.Core.ValueObjects;

namespace tm.Infrastructure.DAL.Repositories;

internal sealed class SqlServerUserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public SqlServerUserRepository(tmDbContext dbContext)
    {
        _users = dbContext.Users;
    }

    public Task<User> GetByIdAsync(UserId id)
        => _users.SingleOrDefaultAsync(x => x.Id == id);

    public Task<User> GetByEmailAsync(Email email)
        => _users.SingleOrDefaultAsync(x => x.Email == email);

    public Task<User> GetByUsernameAsync(UserName username)
        => _users.SingleOrDefaultAsync(x => x.UserName == username);

    public async Task AddAsync(User user)
        => await _users.AddAsync(user);
}
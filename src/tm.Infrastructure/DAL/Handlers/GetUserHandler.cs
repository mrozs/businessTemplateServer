using Microsoft.EntityFrameworkCore;
using tm.Application.Abstractions;
using tm.Application.DTO;
using tm.Application.Queries;
using tm.Core.ValueObjects;

namespace tm.Infrastructure.DAL.Handlers;

internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDTO>
{
    private readonly tmDbContext _dbContext;

    public GetUserHandler(tmDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<UserDTO> HandleAsync(GetUser query)
    {
        var userId = new UserId(query.UserId);
        var user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == userId);

        return user?.AsDto();
    }
}
using Microsoft.EntityFrameworkCore;
using tm.Application.Abstractions;
using tm.Application.DTO;
using tm.Application.Queries;
using tm.Infrastructure.DAL;
using tm.Infrastructure.DAL.Handlers;

namespace MySpot.Infrastructure.DAL.Handlers;

internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDTO>>
{
    private readonly tmDbContext _dbContext;

    public GetUsersHandler(tmDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<UserDTO>> HandleAsync(GetUsers query)
        => await _dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();
}
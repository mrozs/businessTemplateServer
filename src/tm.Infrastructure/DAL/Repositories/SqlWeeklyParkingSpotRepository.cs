using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using tm.Core.Abstractions;
using tm.Core.Entities;
using tm.Core.Repositories;
using tm.Core.ValueObjects;

namespace tm.Infrastructure.DAL.Repositories;

internal sealed class SqlWeeklyParkingSpotRepository : IWeeklyParkingSpotRepository
{
    private readonly tmDbContext _dbContext;

    public SqlWeeklyParkingSpotRepository(tmDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(WeeklyParkingSpot weeklyParkingSpot)
    {
        await _dbContext.AddAsync(weeklyParkingSpot);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(WeeklyParkingSpot weeklyParkingSpot) {
        _dbContext.Remove(weeklyParkingSpot);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<WeeklyParkingSpot> GetAsync(ParkingSpotId id)
    {
        return await _dbContext.WeeklyParkingSpots
            .Include(x => x.Reservations)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week)
    {
        var result = await _dbContext.WeeklyParkingSpots
            .Include(x => x.Reservations)
            .Where(x => x.Week == week)
            .ToListAsync();
        return result.AsEnumerable();
    }

    public async Task<IEnumerable<WeeklyParkingSpot>> GetAllAsync()
    {
        var result = await _dbContext.WeeklyParkingSpots
            .Include(x => x.Reservations)
            .ToListAsync();
        return result.AsEnumerable();
    }

    public async Task UpdateAsync(WeeklyParkingSpot weeklyParkingSpot)
    {
        _dbContext.Update(weeklyParkingSpot);
        await _dbContext.SaveChangesAsync();
    }
}
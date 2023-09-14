using tm.Core.Entities;
using tm.Core.ValueObjects;

namespace tm.Core.Repositories;

public interface IWeeklyParkingSpotRepository
{
    Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week) => throw new NotImplementedException();
    Task<IEnumerable<WeeklyParkingSpot>> GetAllAsync();
    Task<WeeklyParkingSpot> GetAsync(ParkingSpotId id);
    Task AddAsync(WeeklyParkingSpot weeklyParkingSpot);
    Task UpdateAsync(WeeklyParkingSpot weeklyParkingSpot);
    Task DeleteAsync(WeeklyParkingSpot weeklyParkingSpot);
}

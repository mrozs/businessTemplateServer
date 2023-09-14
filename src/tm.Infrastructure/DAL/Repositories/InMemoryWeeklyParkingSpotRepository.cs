using tm.Core.Abstractions;
using tm.Core.Entities;
using tm.Core.Repositories;
using tm.Core.ValueObjects;

namespace tm.Infrastructure.DAL.Repositories;

public sealed class InMemoryWeeklyParkingSpotRepository : IWeeklyParkingSpotRepository
{
    private readonly IClock _clock;
    private readonly List<WeeklyParkingSpot> _weeklyParkingSpots;

    public InMemoryWeeklyParkingSpotRepository(IClock clock)
    {
        _clock = clock;
        _weeklyParkingSpots = new List<WeeklyParkingSpot>() {
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000001"), new Week(new Date(_clock.Current())), "P1"),
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000002"), new Week(new Date(_clock.Current())), "P2"),
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000003"), new Week(new Date(_clock.Current())), "P3"),
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000004"), new Week(new Date(_clock.Current())), "P4"),
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000005"), new Week(new Date(_clock.Current())), "P5")
        };
    }

    public Task AddAsync(WeeklyParkingSpot weeklyParkingSpot)
    {
        _weeklyParkingSpots.Add(weeklyParkingSpot);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(WeeklyParkingSpot weeklyParkingSpot)
    {
        _weeklyParkingSpots.Remove(weeklyParkingSpot);
        return Task.CompletedTask;
    }

    public Task<WeeklyParkingSpot> GetAsync(ParkingSpotId id) => Task.FromResult(_weeklyParkingSpots.SingleOrDefault(x => x.Id == id));

    public Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week)
    {
        var result = _weeklyParkingSpots
            .Where(x => x.Week == week)
            .ToList();
        return (Task<IEnumerable<WeeklyParkingSpot>>)result.AsEnumerable();
    }

    public Task<IEnumerable<WeeklyParkingSpot>> GetAllAsync() => Task.FromResult(_weeklyParkingSpots.AsEnumerable());

    public Task UpdateAsync(WeeklyParkingSpot weeklyParkingSpot) => Task.CompletedTask;
}
using Microsoft.EntityFrameworkCore;
using tm.Application.Abstractions;
using tm.Application.DTO;
using tm.Application.Queries;
using tm.Core.ValueObjects;

namespace tm.Infrastructure.DAL.Handlers
{
    internal sealed class GetWeeklyParkingSpotsHandler : IQueryHandler<GetWeeklyParkingSpots, IEnumerable<WeeklyParkingSpotDTO>>
    {
        private readonly tmDbContext _context;

        public GetWeeklyParkingSpotsHandler(tmDbContext context)
        {
            _context = context;     
        }

        public async Task<IEnumerable<WeeklyParkingSpotDTO>> HandleAsync(GetWeeklyParkingSpots query)
        {
            var week = query.Date.HasValue ? new Week(query.Date.Value) : null;
            var weeklyParkingSpots = await _context.WeeklyParkingSpots
                .Where(x => week == null || x.Week == week)
                .Include(x => x.Reservations)
                .AsNoTracking()
                .ToListAsync();

            return weeklyParkingSpots.Select(x => x.AsDto());
        }
    }
}

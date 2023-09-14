using tm.Application.Abstractions;
using tm.Application.DTO;

namespace tm.Application.Queries;

public class GetWeeklyParkingSpots : IQuery<IEnumerable<WeeklyParkingSpotDTO>>
{
    public DateTime? Date { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

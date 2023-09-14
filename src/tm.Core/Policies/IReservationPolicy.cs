using tm.Core.Entities;
using tm.Core.ValueObjects;

namespace tm.Core.Policies
{
    public interface IReservationPolicy
    {
        bool CanBeApplied(JobTitle jobTitle);
        bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName);
    }
}

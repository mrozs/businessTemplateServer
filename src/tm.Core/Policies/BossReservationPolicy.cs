using tm.Core.Entities;
using tm.Core.ValueObjects;

namespace tm.Core.Policies
{
    internal sealed class BossReservationPolicy : IReservationPolicy
    {
        public bool CanBeApplied(JobTitle jobTitle) => jobTitle == JobTitle.Boss;

        public bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName) => true;
    }
}

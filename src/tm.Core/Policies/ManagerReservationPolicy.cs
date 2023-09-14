using tm.Core.Entities;
using tm.Core.ValueObjects;

namespace tm.Core.Policies
{
    internal sealed class ManagerReservationPolicy : IReservationPolicy
    {
        public bool CanBeApplied(JobTitle jobTitle) => jobTitle == JobTitle.Manager;

        public bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName)
        {
            var totalEmplyeeReservations = weeklyParkingSpots
                .SelectMany(x => x.Reservations)
                .OfType<VehicleReservation>()
                .Count(x => x.EmployeeName == employeeName);

            return totalEmplyeeReservations < 4;
        }
    }
}

using tm.Core.Abstractions;
using tm.Core.Entities;
using tm.Core.ValueObjects;

namespace tm.Core.Policies
{
    internal sealed class RegularEmployeeReservationPolicy : IReservationPolicy
    {
        private IClock _clock;

        public RegularEmployeeReservationPolicy(IClock clock)
        {
            _clock = clock;
        }

        public bool CanBeApplied(JobTitle jobTitle) => jobTitle == JobTitle.Employee;

        public bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName)
        {
            var totalEmplyeeReservations = weeklyParkingSpots
                .SelectMany(x => x.Reservations)
                .OfType<VehicleReservation>()
                .Count(x => x.EmployeeName == employeeName);

            return totalEmplyeeReservations < 2 && _clock.Current().Hour > 4;
        }
    }
}

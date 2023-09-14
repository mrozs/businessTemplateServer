using tm.Core.Entities;
using tm.Core.ValueObjects;

namespace tm.Core.DomainServices
{
    public interface IParkingReservationService
    {
        void ReserveSpotForVehicle(IEnumerable<WeeklyParkingSpot> allParkingSpots, JobTitle jobTitle,
            WeeklyParkingSpot parkingSpotToReserve, VehicleReservation reservation);

        void ReserveParkingForCleaning(IEnumerable<WeeklyParkingSpot> allParkingSpots, Date date);
    }
}

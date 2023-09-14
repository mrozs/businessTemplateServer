using tm.Core.Exceptions;
using tm.Core.ValueObjects;

namespace tm.Core.Entities;

public sealed class CleaningReservation : Reservation
{
    private CleaningReservation()
    {

    }

    public CleaningReservation(ReservationId id, ParkingSpotId parkingSpotId, Date date) :
    base(id, parkingSpotId, 2, date)
    {
    }
}

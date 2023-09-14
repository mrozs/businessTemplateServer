using tm.Core.Exceptions;
using tm.Core.ValueObjects;

namespace tm.Core.Entities;

public abstract class Reservation
{
    public ReservationId Id { get; }
    public ParkingSpotId ParkingSpotId { get; }
    public Date Date { get; private set; }

    public Capacity Capacity { get; private set; }

    protected Reservation()
    {

    }

    public Reservation(ReservationId id, ParkingSpotId parkingSpotId, Capacity capacity, Date date)
    {
        Id = id;
        ParkingSpotId = parkingSpotId;
        Capacity = capacity;
        Date = date;
    }
}

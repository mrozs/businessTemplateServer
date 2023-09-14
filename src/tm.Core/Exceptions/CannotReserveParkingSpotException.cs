using tm.Core.ValueObjects;

namespace tm.Core.Exceptions;

public sealed class CannotReserveParkingSpotException : CustomException
{
    public ParkingSpotId ParkingSpotId { get; }

    public CannotReserveParkingSpotException(ParkingSpotId parkingSpotId) : base($"Cannot reserve {parkingSpotId}")
    {
        ParkingSpotId = parkingSpotId;    
    }
}
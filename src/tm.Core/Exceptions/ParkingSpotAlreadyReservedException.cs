namespace tm.Core.Exceptions;

public sealed class ParkingSpotAlreadyReservedException : CustomException
{
    public DateTime Date { get; }
    public string Name { get; }

    public ParkingSpotAlreadyReservedException(string name, DateTime date) : base($"Parking spot {name} is already reserved at {date:d}")
    {
        Date = date;
        Name = name;
    }
}
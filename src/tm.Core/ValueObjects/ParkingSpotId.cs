using tm.Core.Exceptions;

namespace tm.Core.ValueObjects;

public sealed record ParkingSpotId(Guid Value)
{
    public Guid Value { get; } = Value;
    public static implicit operator Guid(ParkingSpotId name) => name.Value;
    public static implicit operator ParkingSpotId(Guid value) => new (value);
}

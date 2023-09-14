using tm.Application.Abstractions;
using tm.Core.ValueObjects;

namespace tm.Application.Commands;

public record ReserveParkingSpotForVehicle(Guid ParkingSpotId, Guid ReservationId, string EmployeeName, 
    string LicensePlate, Capacity Capacity, DateTime Date) : ICommand;

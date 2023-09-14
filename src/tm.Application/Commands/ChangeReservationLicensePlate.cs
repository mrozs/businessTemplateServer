using tm.Application.Abstractions;

namespace tm.Application.Commands;

public record ChangeReservationLicensePlate(Guid ReservationId, string LicensePlate) : ICommand;

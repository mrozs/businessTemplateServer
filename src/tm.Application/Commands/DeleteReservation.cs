using tm.Application.Abstractions;

namespace tm.Application.Commands;

public record DeleteReservation(Guid ReservationId) : ICommand;

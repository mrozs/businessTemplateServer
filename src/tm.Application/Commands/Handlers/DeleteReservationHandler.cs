using tm.Application.Abstractions;
using tm.Application.Exceptions;
using tm.Core.Abstractions;
using tm.Core.DomainServices;
using tm.Core.Entities;
using tm.Core.Repositories;
using tm.Core.ValueObjects;

namespace tm.Application.Commands.Handlers;

public sealed class DeleteReservationHandler : ICommandHandler<DeleteReservation>
{
    private readonly IWeeklyParkingSpotRepository _repository;

    public DeleteReservationHandler(IWeeklyParkingSpotRepository repository)
        => _repository = repository;

    public async Task HandleAsync(DeleteReservation command)
    {
        var weeklyParkingSpot = await GetWeeklyParkingSpotByReservation(command.ReservationId);
        if (weeklyParkingSpot is null)
        {
            throw new WeeklyParkingSpotNotFoundException();
        }

        weeklyParkingSpot.RemoveReservation(command.ReservationId);
        await _repository.UpdateAsync(weeklyParkingSpot);
    }

    private async Task<WeeklyParkingSpot> GetWeeklyParkingSpotByReservation(ReservationId id)
        => (await _repository.GetAllAsync())
            .SingleOrDefault(x => x.Reservations.Any(r => r.Id == id));
}

using tm.Application.Abstractions;
using tm.Application.Exceptions;
using tm.Core.Abstractions;
using tm.Core.DomainServices;
using tm.Core.Entities;
using tm.Core.Repositories;
using tm.Core.ValueObjects;

namespace tm.Application.Commands.Handlers;

public sealed class ReserveParkingSpotForCleaningHandler : ICommandHandler<ReserveParkingSpotForCleaning>
{
    private readonly IWeeklyParkingSpotRepository _repository;
    private readonly IParkingReservationService _reservationService;

    public ReserveParkingSpotForCleaningHandler(IWeeklyParkingSpotRepository repository,
        IParkingReservationService reservationService)
    {
        _repository = repository;
        _reservationService = reservationService;
    }

    public async Task HandleAsync(ReserveParkingSpotForCleaning command)
    {
        var week = new Week(command.Date);
        var weeklyParkingSpots = (await _repository.GetByWeekAsync(week)).ToList();

        _reservationService.ReserveParkingForCleaning(weeklyParkingSpots, new Date(command.Date));

        var tasks = weeklyParkingSpots.Select(x => _repository.UpdateAsync(x));
        await Task.WhenAll(tasks);
    }
}

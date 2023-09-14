using tm.Core.Abstractions;
using tm.Core.Repositories;
using Xunit;

namespace tm.Tests.Unit.Services;

public class ReservationServiceTests
{
    [Fact]
    public async Task given_reservation_for_not_taken_day_add_reservation_should_succeed()
    {
        //// Arrange
        //var parkingSpots = await _weeklyParkingSpotRepository.GetAllAsync();
        //var parkingSpot = parkingSpots.First();
        //var command = new ReserveParkingSpotForVehicle(parkingSpot.Id, 
        //    Guid.NewGuid(), "John Doe", "12345", DateTime.UtcNow.AddMinutes(5));

        //// Act
        //var reservationId = await _reservationService.ReserveForVehicleAsync(command);

        //// Assert
        //reservationId.ShouldNotBeNull();
        //reservationId.Value.ShouldBe(command.ReservationId);
    }

    #region ARRANGE

    private static IClock _clock;
    private readonly IWeeklyParkingSpotRepository _weeklyParkingSpotRepository;
    //private readonly ReservationsService _reservationService;

    //public ReservationServiceTests()
    //{
    //    _clock = new TestClock();
    //    _weeklyParkingSpotRepository = new InMemoryWeeklyParkingSpotRepository(_clock);

    //    var parkingReservationsService = new ParkingReservationService(new IReservationPolicy[] {
    //        new BossReservationPolicy(),
    //        new ManagerReservationPolicy(),
    //        new RegularEmployeeReservationPolicy(_clock)
    //    }, _clock);

    //    _reservationService = new ReservationsService(_clock, _weeklyParkingSpotRepository, parkingReservationsService);
    //}

    #endregion
}

using Shouldly;
using tm.Core.Entities;
using tm.Core.Exceptions;
using tm.Core.ValueObjects;
using Xunit;

namespace tm.Tests.Unit.Entities;

public class WeeklyParkingSpotTests
{
    [Theory]
    [InlineData("2022-08-09")]
    [InlineData("2022-08-17")]
    public void given_invalid_date_add_reservaton_should_fail(string dateString)
    {
        // Arrange
        var reservationDate = DateTime.Parse(dateString);
        var reservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "12345", 1,  new Date(reservationDate));

        // Act
        var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(reservation, _now));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidReservationDateException>();

        //Assert.NotNull(exception);
        //Assert.IsType<InvalidReservationDateException>(exception);
    }

    [Fact]
    public void given_reservation_for_already_reserved_parking_spot_add_reservation_should_fail()
    {
        // Arrange
        var reservationDate = _now.AddDays(1);
        var reservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "12345", 2, reservationDate);
        var nextReservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "12345", 1, reservationDate);
        _weeklyParkingSpot.AddReservation(reservation, _now);

        // Act
        var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(nextReservation, _now));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ParkingSpotCapacityExceededException>();
    }

    [Fact]
    public void given_reservation_for_not_reserved_spot_add_reservation_should_succeed()
    {
        // Arrange
        var reservationDate = _now.AddDays(1);
        var reservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "12345", 1, reservationDate);

        // Act
        _weeklyParkingSpot.AddReservation(reservation, _now);

        // Assert
        _weeklyParkingSpot.Reservations.ShouldHaveSingleItem();
    }

    #region Arrange

    private readonly Date _now;
    private readonly WeeklyParkingSpot _weeklyParkingSpot;

    public WeeklyParkingSpotTests()
    {
        _now = new Date( new DateTime(2022, 08, 10));
        _weeklyParkingSpot = WeeklyParkingSpot.Create(Guid.NewGuid(), new Week(_now), "P1");
    }

    #endregion
}

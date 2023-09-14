using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tm.Application.Abstractions;
using tm.Application.Commands;

namespace tm.api.Controllers;


[ApiController]
[Route("parking-spots")]
public class ReservationsController : ControllerBase
{
    private readonly ICommandHandler<ReserveParkingSpotForVehicle> _reserveParkingSpotsForVehicleHandler;
    private readonly ICommandHandler<ReserveParkingSpotForCleaning> _reserveParkingSpotsForCleaningHandler;
    private readonly ICommandHandler<ChangeReservationLicensePlate> _changeReservationLicensePlateHandler;
    private readonly ICommandHandler<DeleteReservation> _deleteReservationHandler;

    public ReservationsController(ICommandHandler<ReserveParkingSpotForVehicle> reserveParkingSpotsForVehicleHandler,
        ICommandHandler<ReserveParkingSpotForCleaning> reserveParkingSpotsForCleaningHandler,
        ICommandHandler<ChangeReservationLicensePlate> changeReservationLicensePlateHandler,
        ICommandHandler<DeleteReservation> deleteReservationHandler)
    {
        _reserveParkingSpotsForVehicleHandler = reserveParkingSpotsForVehicleHandler;
        _reserveParkingSpotsForCleaningHandler = reserveParkingSpotsForCleaningHandler;
        _changeReservationLicensePlateHandler = changeReservationLicensePlateHandler;
        _deleteReservationHandler = deleteReservationHandler;
    }


    [Authorize]
    [HttpPost("{parkingSpotId:guid}/reservations/vehicle")]
    public async Task<ActionResult> Post(Guid parkingSpotId, ReserveParkingSpotForVehicle command)
    {
        await _reserveParkingSpotsForVehicleHandler.HandleAsync(command with
        {
            ReservationId = Guid.NewGuid(),
            ParkingSpotId = parkingSpotId,
            //UserId = Guid.Parse(User.Identity.Name)
        });
        return NoContent();
    }

    [HttpPost("reservations/cleaning")]
    public async Task<ActionResult> Post(ReserveParkingSpotForCleaning command)
    {
        await _reserveParkingSpotsForCleaningHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpPut("reservations/{reservationId:guid}")]
    public async Task<ActionResult> Put(Guid reservationId, ChangeReservationLicensePlate command)
    {
        await _changeReservationLicensePlateHandler.HandleAsync(command with { ReservationId = reservationId });
        return NoContent();
    }

    [HttpDelete("reservations/{reservationId:guid}")]
    public async Task<ActionResult> Delete(Guid reservationId)
    {
        await _deleteReservationHandler.HandleAsync(new DeleteReservation(reservationId));
        return NoContent();
    }
}
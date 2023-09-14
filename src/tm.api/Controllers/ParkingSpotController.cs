using Microsoft.AspNetCore.Mvc;
using tm.Application.Abstractions;
using tm.Application.DTO;
using tm.Application.Queries;

namespace tm.api.Controllers;

[ApiController]
[Route("parking-spots")]
public class ParkingSpotsController : ControllerBase
{
    private readonly IQueryHandler<GetWeeklyParkingSpots, IEnumerable<WeeklyParkingSpotDTO>>
        _getWeeklyParkingSpotsHandler;

    public ParkingSpotsController(
        IQueryHandler<GetWeeklyParkingSpots, IEnumerable<WeeklyParkingSpotDTO>> getWeeklyParkingSpotsHandler)
    {
        _getWeeklyParkingSpotsHandler = getWeeklyParkingSpotsHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeeklyParkingSpotDTO>>> Get([FromQuery] GetWeeklyParkingSpots query)
        => Ok(await _getWeeklyParkingSpotsHandler.HandleAsync(query));
}
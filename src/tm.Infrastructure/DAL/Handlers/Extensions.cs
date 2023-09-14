using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tm.Application.DTO;
using tm.Core.Entities;

namespace tm.Infrastructure.DAL.Handlers
{
    internal static class Extensions
    {
        public static WeeklyParkingSpotDTO AsDto(this WeeklyParkingSpot entity) =>
            new()
            {
                Id = entity.Id.Value.ToString(),
                Name = entity.Name.Value,
                Capacity = entity.Capacity.Value,
                From = entity.Week.From.Value.DateTime,
                To = entity.Week.To.Value.DateTime,
                Reservations = entity.Reservations.Select(x => new ReservationDTO
                {
                    Id = x.Id,
                    ParkingSpotId = x.ParkingSpotId,
                    EmployeeName = x is VehicleReservation vr ? vr.EmployeeName : null,
                    Type = x is VehicleReservation ? "vehicle"  : "cleaning",
                    Date = x.Date.Value.Date
                })
            };

        public static UserDTO AsDto(this User entity)
            => new()
            {
                Id = entity.Id,
                UserName = entity.UserName,
                FullName = entity.FullName
            };
    }
}

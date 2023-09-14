namespace tm.Application.DTO;

public class ReservationDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ParkingSpotId { get; set; }
    public string EmployeeName { get; set; }
    public string LicensePlate { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
}

namespace GestionAerolineas.src.Modules.Flights.Infrastructure.Entity;

public class FlightEntity
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public int AirlineId { get; set; }
    public int RouteId { get; set; }
    public int AircraftId { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime EstimatedArrivalDateTime { get; set; }
    public int TotalCapacity { get; set; }
    public int AvailableSeats { get; set; }
    public int StateId { get; set; }
    public DateTime? RescheduledAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}


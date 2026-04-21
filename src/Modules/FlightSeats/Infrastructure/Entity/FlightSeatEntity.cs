namespace GestionAerolineas.src.Modules.FlightSeats.Infrastructure.Entity;

public class FlightSeatEntity
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public string? SeatCode { get; set; }
    public int CabinTypeId { get; set; }
    public int LocationTypeId { get; set; }
    public bool IsOccupied { get; set; }
}


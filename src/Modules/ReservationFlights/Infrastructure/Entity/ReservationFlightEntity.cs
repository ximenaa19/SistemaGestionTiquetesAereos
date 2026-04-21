namespace GestionAerolineas.src.Modules.ReservationFlights.Infrastructure.Entity;

public class ReservationFlightEntity
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public int FlightId { get; set; }
    public decimal PartialAmount { get; set; }
}


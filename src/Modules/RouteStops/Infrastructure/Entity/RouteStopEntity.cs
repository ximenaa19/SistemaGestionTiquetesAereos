namespace GestionAerolineas.src.Modules.RouteStops.Infrastructure.Entity;

public class RouteStopEntity
{
    public int Id { get; set; }
    public int RouteId { get; set; }
    public int StopAirportId { get; set; }
    public int Order { get; set; }
    public int DurationMinutes { get; set; }
}


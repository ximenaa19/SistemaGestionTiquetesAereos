namespace GestionAerolineas.src.Modules.Routes.Infrastructure.Entity;

public class RouteEntity
{
    public int Id { get; set; }
    public int OriginAirportId { get; set; }
    public int DestinationAirportId { get; set; }
    public int? DistanceKm { get; set; }
    public int? EstimatedDurationMin { get; set; }
}


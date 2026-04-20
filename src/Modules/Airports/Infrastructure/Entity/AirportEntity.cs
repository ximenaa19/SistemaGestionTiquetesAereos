namespace GestionAerolineas.src.Modules.Airports.Infrastructure.Entity;

public class AirportEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? IataCode { get; set; }
    public string? IcaoCode { get; set; }
    public int CityId { get; set; }
}

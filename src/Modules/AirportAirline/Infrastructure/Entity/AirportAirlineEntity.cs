namespace GestionAerolineas.src.Modules.AirportAirline.Infrastructure.Entity;

public class AirportAirlineEntity
{
    public int Id { get; set; }
    public int AirportId { get; set; }
    public int AirlineId { get; set; }
    public string? Terminal { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }
}


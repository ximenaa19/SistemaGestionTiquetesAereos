namespace GestionAerolineas.src.Modules.Aircraft.Infrastructure.Entity;

public class AircraftEntity
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public int AirlineId { get; set; }
    public string? Registration { get; set; }
    public DateTime? ManufactureDate { get; set; }
    public bool IsActive { get; set; }
}


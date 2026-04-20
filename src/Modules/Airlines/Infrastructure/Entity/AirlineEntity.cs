namespace GestionAerolineas.src.Modules.Airlines.Infrastructure.Entity;

public class AirlineEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? IataCode { get; set; }
    public int OriginCountryId { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}


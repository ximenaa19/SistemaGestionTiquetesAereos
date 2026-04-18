namespace GestionAerolineas.src.Modules.Seasons.Infrastructure.Entity;

public class SeasonEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal PriceFactor { get; set; }
}

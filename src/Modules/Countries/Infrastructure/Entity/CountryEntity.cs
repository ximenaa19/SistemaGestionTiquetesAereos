namespace GestionAerolineas.src.Modules.Countries.Infrastructure.Entity;

public class CountryEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? IsoCode { get; set; }
    public int ContinentId { get; set; }
}


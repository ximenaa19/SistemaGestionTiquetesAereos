namespace GestionAerolineas.src.Modules.Addresses.Infrastructure.Entity;

public class AddressEntity
{
    public int Id { get; set; }
    public int RoadTypeId { get; set; }
    public string? RoadName { get; set; }
    public string? Number { get; set; }
    public string? Complement { get; set; }
    public int CityId { get; set; }
    public string? PostalCode { get; set; }
}


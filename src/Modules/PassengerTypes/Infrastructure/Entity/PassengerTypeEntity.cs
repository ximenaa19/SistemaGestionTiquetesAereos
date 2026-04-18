namespace GestionAerolineas.src.Modules.PassengerTypes.Infrastructure.Entity;

public class PassengerTypeEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? AgeMin { get; set; }
    public int? AgeMax { get; set; }
}


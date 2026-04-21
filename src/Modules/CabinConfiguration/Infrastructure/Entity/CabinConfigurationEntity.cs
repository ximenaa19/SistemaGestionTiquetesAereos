namespace GestionAerolineas.src.Modules.CabinConfiguration.Infrastructure.Entity;

public class CabinConfigurationEntity
{
    public int Id { get; set; }
    public int AircraftId { get; set; }
    public int CabinTypeId { get; set; }
    public int StartRow { get; set; }
    public int EndRow { get; set; }
    public int SeatsPerRow { get; set; }
    public string? SeatLetters { get; set; }
}


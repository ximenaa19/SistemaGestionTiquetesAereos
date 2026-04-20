namespace GestionAerolineas.src.Modules.AircraftModels.Infrastructure.Entity;

public class AircraftModelEntity
{
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public string? ModelName { get; set; }
    public int MaxCapacity { get; set; }
    public decimal? MaxTakeoffWeightKg { get; set; }
    public decimal? FuelConsumptionKgPerHour { get; set; }
    public int? CruiseSpeedKmh { get; set; }
    public int? CruiseAltitudeFt { get; set; }
}


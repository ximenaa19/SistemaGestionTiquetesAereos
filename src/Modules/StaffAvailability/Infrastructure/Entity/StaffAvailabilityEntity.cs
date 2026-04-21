namespace GestionAerolineas.src.Modules.StaffAvailability.Infrastructure.Entity;

public class StaffAvailabilityEntity
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public int AvailabilityStatusId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string? Observation { get; set; }
}


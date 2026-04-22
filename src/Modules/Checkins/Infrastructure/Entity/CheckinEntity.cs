namespace GestionAerolineas.src.Modules.Checkins.Infrastructure.Entity;

public class CheckinEntity
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public int StaffId { get; set; }
    public int FlightSeatId { get; set; }
    public DateTime CheckedAt { get; set; }
    public int StatusId { get; set; }
    public string? BoardingPassNumber { get; set; }
    public bool HasHoldBaggage { get; set; }
    public decimal? BaggageWeightKg { get; set; }
}


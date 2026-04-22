namespace GestionAerolineas.src.Modules.Tickets.Infrastructure.Entity;

public class TicketEntity
{
    public int Id { get; set; }
    public int ReservationPassengerId { get; set; }
    public string? Code { get; set; }
    public DateTime IssuedAt { get; set; }
    public int StatusId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}


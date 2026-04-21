namespace GestionAerolineas.src.Modules.Reservations.Infrastructure.Entity;

public class ReservationEntity
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public int CustomerId { get; set; }
    public DateTime ReservedAt { get; set; }
    public int StatusId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}


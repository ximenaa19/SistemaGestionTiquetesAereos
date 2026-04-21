namespace GestionAerolineas.src.Modules.Payments.Infrastructure.Entity;

public class PaymentEntity
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaidAt { get; set; }
    public int StateId { get; set; }
    public int MethodId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}


namespace GestionAerolineas.src.Modules.Invoices.Infrastructure.Entity;

public class InvoiceEntity
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public string? InvoiceNumber { get; set; }
    public DateTime IssuedAt { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Taxes { get; set; }
    public decimal Total { get; set; }
    public DateTime? CreatedAt { get; set; }
}

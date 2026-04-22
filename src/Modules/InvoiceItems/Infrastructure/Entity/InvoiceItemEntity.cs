namespace GestionAerolineas.src.Modules.InvoiceItems.Infrastructure.Entity;

public class InvoiceItemEntity
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int ItemTypeId { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
    public int? ReservationPassengerId { get; set; }
}


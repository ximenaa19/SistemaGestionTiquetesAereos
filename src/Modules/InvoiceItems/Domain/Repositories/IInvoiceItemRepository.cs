using GestionAerolineas.src.Modules.InvoiceItems.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItems.Domain.Repositories;

public interface IInvoiceItemRepository
{
    Task<IEnumerable<InvoiceItem>> GetAllAsync();
    Task<InvoiceItem?> GetByIdAsync(InvoiceItemId id);
    Task<IEnumerable<InvoiceItem>> GetByInvoiceIdAsync(int invoiceId);
    Task<IEnumerable<InvoiceItem>> GetByItemTypeIdAsync(InvoiceItemTypeId itemTypeId);
    Task<IEnumerable<InvoiceItem>> GetByReservationPassengerIdAsync(int reservationPassengerId);
    Task AddAsync(InvoiceItem item);
    Task UpdateAsync(InvoiceItem item);
    Task DeleteAsync(InvoiceItem item);
    Task<bool> ExistsAsync(InvoiceItemId id);
    Task<bool> AnyByInvoiceIdAsync(int invoiceId);
}


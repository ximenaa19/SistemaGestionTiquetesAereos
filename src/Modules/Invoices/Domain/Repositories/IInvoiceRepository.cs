using GestionAerolineas.src.Modules.Invoices.Domain.Aggregate;
using GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Invoices.Domain.Repositories;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetAllAsync();
    Task<Invoice?> GetByIdAsync(InvoiceId id);
    Task<Invoice?> GetByNumberAsync(InvoiceNumber number);
    Task<Invoice?> GetByReservationIdAsync(InvoiceReservationId reservationId);
    Task<IEnumerable<Invoice>> GetByIssuedAtRangeAsync(DateTime fromInclusive, DateTime toInclusive);
    Task AddAsync(Invoice invoice);
    Task UpdateAsync(Invoice invoice);
    Task DeleteAsync(Invoice invoice);
    Task<bool> ExistsAsync(InvoiceId id);
    Task<bool> ExistsByReservationIdAsync(int reservationId, int? excludingInvoiceId = null);
    Task<bool> ExistsByNormalizedNumberAsync(string normalizedNumber, int? excludingInvoiceId = null);
}


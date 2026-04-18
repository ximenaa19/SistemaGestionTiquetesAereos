using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Repositories;

public interface IInvoiceItemTypeRepository
{
    Task<IEnumerable<InvoiceItemType>> GetAllAsync();
    Task<InvoiceItemType?> GetByIdAsync(InvoiceItemTypeId id);
    Task<InvoiceItemType?> GetByNameAsync(InvoiceItemTypeName name);
    Task AddAsync(InvoiceItemType invoiceItemType);
    Task UpdateAsync(InvoiceItemType invoiceItemType);
    Task DeleteAsync(InvoiceItemType invoiceItemType);
    Task<bool> ExistsAsync(InvoiceItemTypeId id);
}

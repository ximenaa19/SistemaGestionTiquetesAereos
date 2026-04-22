using GestionAerolineas.src.Modules.InvoiceItems.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItems.Domain.Repositories;

namespace GestionAerolineas.src.Modules.InvoiceItems.Application.UseCases;

public class GetInvoiceItemsByInvoiceIdUseCase
{
    private readonly IInvoiceItemRepository _repository;

    public GetInvoiceItemsByInvoiceIdUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<InvoiceItem>> ExecuteAsync(int invoiceId)
    {
        return _repository.GetByInvoiceIdAsync(invoiceId);
    }
}


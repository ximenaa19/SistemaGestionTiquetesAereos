using GestionAerolineas.src.Modules.InvoiceItems.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItems.Domain.Repositories;

namespace GestionAerolineas.src.Modules.InvoiceItems.Application.UseCases;

public class GetAllInvoiceItemsUseCase
{
    private readonly IInvoiceItemRepository _repository;

    public GetAllInvoiceItemsUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<InvoiceItem>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


using GestionAerolineas.src.Modules.InvoiceItems.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItems.Domain.Repositories;
using GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItems.Application.UseCases;

public class GetInvoiceItemByIdUseCase
{
    private readonly IInvoiceItemRepository _repository;

    public GetInvoiceItemByIdUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    public Task<InvoiceItem?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(InvoiceItemId.Create(id));
    }
}


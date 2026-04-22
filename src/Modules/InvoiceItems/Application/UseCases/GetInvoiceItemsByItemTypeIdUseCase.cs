using GestionAerolineas.src.Modules.InvoiceItems.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItems.Domain.Repositories;
using GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItems.Application.UseCases;

public class GetInvoiceItemsByItemTypeIdUseCase
{
    private readonly IInvoiceItemRepository _repository;

    public GetInvoiceItemsByItemTypeIdUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<InvoiceItem>> ExecuteAsync(int itemTypeId)
    {
        return _repository.GetByItemTypeIdAsync(InvoiceItemTypeId.Create(itemTypeId));
    }
}


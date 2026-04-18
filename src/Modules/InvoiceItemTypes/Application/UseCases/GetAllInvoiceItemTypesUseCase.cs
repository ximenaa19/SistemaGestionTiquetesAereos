using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Repositories;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Application.UseCases;

public class GetAllInvoiceItemTypesUseCase
{
    private readonly IInvoiceItemTypeRepository _repository;

    public GetAllInvoiceItemTypesUseCase(IInvoiceItemTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InvoiceItemType>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

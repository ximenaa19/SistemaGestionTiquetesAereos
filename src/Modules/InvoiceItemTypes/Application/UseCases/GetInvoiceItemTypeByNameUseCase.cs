using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Application.UseCases;

public class GetInvoiceItemTypeByNameUseCase
{
    private readonly IInvoiceItemTypeRepository _repository;

    public GetInvoiceItemTypeByNameUseCase(IInvoiceItemTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<InvoiceItemType?> ExecuteAsync(string name)
    {
        var nameVO = InvoiceItemTypeName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}

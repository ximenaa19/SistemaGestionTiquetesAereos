using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Application.UseCases;

public class DeleteInvoiceItemTypeUseCase
{
    private readonly IInvoiceItemTypeRepository _repository;

    public DeleteInvoiceItemTypeUseCase(IInvoiceItemTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var invoiceItemTypeId = InvoiceItemTypeId.Create(id);
        var invoiceItemType = await _repository.GetByIdAsync(invoiceItemTypeId);

        if (invoiceItemType is null)
            throw new KeyNotFoundException($"InvoiceItemType con id '{invoiceItemTypeId.Value}' no existe.");

        await _repository.DeleteAsync(invoiceItemType);
    }
}

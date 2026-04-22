using GestionAerolineas.src.Modules.InvoiceItems.Domain.Repositories;
using GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.InvoiceItems.Application.UseCases;

public class DeleteInvoiceItemUseCase
{
    private readonly IInvoiceItemRepository _repository;

    public DeleteInvoiceItemUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var idVO = InvoiceItemId.Create(id);
        var existing = await _repository.GetByIdAsync(idVO);
        if (existing is null)
            throw new Exception("El item no existe");

        await _repository.DeleteAsync(existing);
    }
}


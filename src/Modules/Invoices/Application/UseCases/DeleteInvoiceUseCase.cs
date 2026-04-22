using GestionAerolineas.src.Modules.Invoices.Application.Interfaces;
using GestionAerolineas.src.Modules.Invoices.Domain.Repositories;
using GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Invoices.Application.UseCases;

public class DeleteInvoiceUseCase
{
    private readonly IInvoiceRepository _repository;
    private readonly IInvoiceValidator _validator;

    public DeleteInvoiceUseCase(IInvoiceRepository repository, IInvoiceValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id)
    {
        var idVO = InvoiceId.Create(id);
        var existing = await _repository.GetByIdAsync(idVO);
        if (existing is null)
            throw new Exception("La factura no existe");

        await _validator.ValidateDeletableAsync(idVO);
        await _repository.DeleteAsync(existing);
    }
}


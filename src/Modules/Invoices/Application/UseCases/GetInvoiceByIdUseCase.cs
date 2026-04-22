using GestionAerolineas.src.Modules.Invoices.Domain.Aggregate;
using GestionAerolineas.src.Modules.Invoices.Domain.Repositories;
using GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Invoices.Application.UseCases;

public class GetInvoiceByIdUseCase
{
    private readonly IInvoiceRepository _repository;

    public GetInvoiceByIdUseCase(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public Task<Invoice?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(InvoiceId.Create(id));
    }
}


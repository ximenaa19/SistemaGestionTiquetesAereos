using GestionAerolineas.src.Modules.Invoices.Domain.Aggregate;
using GestionAerolineas.src.Modules.Invoices.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Invoices.Application.UseCases;

public class GetAllInvoicesUseCase
{
    private readonly IInvoiceRepository _repository;

    public GetAllInvoicesUseCase(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Invoice>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


using GestionAerolineas.src.Modules.Invoices.Domain.Aggregate;
using GestionAerolineas.src.Modules.Invoices.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Invoices.Application.UseCases;

public class GetInvoicesByIssueDateRangeUseCase
{
    private readonly IInvoiceRepository _repository;

    public GetInvoicesByIssueDateRangeUseCase(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Invoice>> ExecuteAsync(DateTime fromInclusive, DateTime toInclusive)
    {
        return _repository.GetByIssuedAtRangeAsync(fromInclusive, toInclusive);
    }
}


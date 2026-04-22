using GestionAerolineas.src.Modules.Invoices.Domain.Aggregate;
using GestionAerolineas.src.Modules.Invoices.Domain.Repositories;
using GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Invoices.Application.UseCases;

public class GetInvoiceByNumberUseCase
{
    private readonly IInvoiceRepository _repository;

    public GetInvoiceByNumberUseCase(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public Task<Invoice?> ExecuteAsync(string number)
    {
        return _repository.GetByNumberAsync(InvoiceNumber.Create(number));
    }
}


using GestionAerolineas.src.Modules.Invoices.Domain.Aggregate;
using GestionAerolineas.src.Modules.Invoices.Domain.Repositories;
using GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Invoices.Application.UseCases;

public class GetInvoiceByReservationIdUseCase
{
    private readonly IInvoiceRepository _repository;

    public GetInvoiceByReservationIdUseCase(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public Task<Invoice?> ExecuteAsync(int reservationId)
    {
        return _repository.GetByReservationIdAsync(InvoiceReservationId.Create(reservationId));
    }
}


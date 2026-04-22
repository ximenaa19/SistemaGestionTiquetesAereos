using GestionAerolineas.src.Modules.InvoiceItems.Domain.Aggregate;
using GestionAerolineas.src.Modules.InvoiceItems.Domain.Repositories;

namespace GestionAerolineas.src.Modules.InvoiceItems.Application.UseCases;

public class GetInvoiceItemsByReservationPassengerIdUseCase
{
    private readonly IInvoiceItemRepository _repository;

    public GetInvoiceItemsByReservationPassengerIdUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<InvoiceItem>> ExecuteAsync(int reservationPassengerId)
    {
        return _repository.GetByReservationPassengerIdAsync(reservationPassengerId);
    }
}


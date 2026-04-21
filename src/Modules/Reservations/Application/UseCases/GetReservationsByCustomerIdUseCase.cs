using GestionAerolineas.src.Modules.Reservations.Domain.Aggregate;
using GestionAerolineas.src.Modules.Reservations.Domain.Repositories;
using GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Reservations.Application.UseCases;

public class GetReservationsByCustomerIdUseCase
{
    private readonly IReservationRepository _repository;

    public GetReservationsByCustomerIdUseCase(IReservationRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Reservation>> ExecuteAsync(int customerId)
    {
        return _repository.GetByCustomerIdAsync(ReservationCustomerId.Create(customerId));
    }
}


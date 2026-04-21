using GestionAerolineas.src.Modules.Reservations.Domain.Aggregate;
using GestionAerolineas.src.Modules.Reservations.Domain.Repositories;
using GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Reservations.Application.UseCases;

public class GetReservationsByStatusIdUseCase
{
    private readonly IReservationRepository _repository;

    public GetReservationsByStatusIdUseCase(IReservationRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Reservation>> ExecuteAsync(int statusId)
    {
        return _repository.GetByStatusIdAsync(ReservationStatusId.Create(statusId));
    }
}


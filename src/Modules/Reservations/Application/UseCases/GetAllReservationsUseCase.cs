using GestionAerolineas.src.Modules.Reservations.Domain.Aggregate;
using GestionAerolineas.src.Modules.Reservations.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Reservations.Application.UseCases;

public class GetAllReservationsUseCase
{
    private readonly IReservationRepository _repository;

    public GetAllReservationsUseCase(IReservationRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Reservation>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


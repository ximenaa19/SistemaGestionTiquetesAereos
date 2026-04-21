using GestionAerolineas.src.Modules.Reservations.Domain.Aggregate;
using GestionAerolineas.src.Modules.Reservations.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Reservations.Application.UseCases;

public class GetReservationsByDateRangeUseCase
{
    private readonly IReservationRepository _repository;

    public GetReservationsByDateRangeUseCase(IReservationRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Reservation>> ExecuteAsync(DateTime fromInclusive, DateTime toInclusive)
    {
        return _repository.GetByReservedAtRangeAsync(fromInclusive, toInclusive);
    }
}


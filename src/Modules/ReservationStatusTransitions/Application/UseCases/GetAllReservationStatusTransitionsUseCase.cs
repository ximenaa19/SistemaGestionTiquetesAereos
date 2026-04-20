using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.Repositories;

namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.Application.UseCases;

public class GetAllReservationStatusTransitionsUseCase
{
    private readonly IReservationStatusTransitionRepository _repository;

    public GetAllReservationStatusTransitionsUseCase(IReservationStatusTransitionRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ReservationStatusTransition>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

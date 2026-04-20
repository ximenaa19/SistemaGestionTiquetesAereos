using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.Application.UseCases;

public class GetReservationStatusTransitionByIdUseCase
{
    private readonly IReservationStatusTransitionRepository _repository;

    public GetReservationStatusTransitionByIdUseCase(IReservationStatusTransitionRepository repository)
    {
        _repository = repository;
    }

    public Task<ReservationStatusTransition?> ExecuteAsync(int id)
    {
        var idVO = ReservationStatusTransitionId.Create(id);
        return _repository.GetByIdAsync(idVO);
    }
}

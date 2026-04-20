using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.Application.UseCases;

public class GetReservationStatusTransitionByPairUseCase
{
    private readonly IReservationStatusTransitionRepository _repository;

    public GetReservationStatusTransitionByPairUseCase(IReservationStatusTransitionRepository repository)
    {
        _repository = repository;
    }

    public Task<ReservationStatusTransition?> ExecuteAsync(int originStatusId, int destinationStatusId)
    {
        var originVO = ReservationStatusOriginId.Create(originStatusId);
        var destinationVO = ReservationStatusDestinationId.Create(destinationStatusId);

        return _repository.GetByPairAsync(originVO, destinationVO);
    }
}

using GestionAerolineas.src.Modules.ReservationStatusTransitions.Application.Interfaces;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.Application.UseCases;

public class CreateReservationStatusTransitionUseCase
{
    private readonly IReservationStatusTransitionRepository _repository;
    private readonly IReservationStatusTransitionValidator _validator;

    public CreateReservationStatusTransitionUseCase(
        IReservationStatusTransitionRepository repository,
        IReservationStatusTransitionValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int originStatusId, int destinationStatusId)
    {
        var originVO = ReservationStatusOriginId.Create(originStatusId);
        var destinationVO = ReservationStatusDestinationId.Create(destinationStatusId);

        await _validator.ValidatePairAsync(originVO, destinationVO);

        var entity = ReservationStatusTransition.CreateNew(originVO, destinationVO);

        await _repository.AddAsync(entity);
    }
}

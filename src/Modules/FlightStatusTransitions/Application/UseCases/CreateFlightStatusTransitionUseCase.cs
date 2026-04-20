using GestionAerolineas.src.Modules.FlightStatusTransitions.Application.Interfaces;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStatusTransitions.Application.UseCases;

public class CreateFlightStatusTransitionUseCase
{
    private readonly IFlightStatusTransitionRepository _repository;
    private readonly IFlightStatusTransitionValidator _validator;

    public CreateFlightStatusTransitionUseCase(
        IFlightStatusTransitionRepository repository,
        IFlightStatusTransitionValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int originStateId, int destinationStateId)
    {
        var originVO = FlightStateOriginId.Create(originStateId);
        var destinationVO = FlightStateDestinationId.Create(destinationStateId);

        await _validator.ValidatePairAsync(originVO, destinationVO);

        var entity = FlightStatusTransition.CreateNew(originVO, destinationVO);

        await _repository.AddAsync(entity);
    }
}


using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.Repositories;

namespace GestionAerolineas.src.Modules.FlightStatusTransitions.Application.UseCases;

public class GetAllFlightStatusTransitionsUseCase
{
    private readonly IFlightStatusTransitionRepository _repository;

    public GetAllFlightStatusTransitionsUseCase(IFlightStatusTransitionRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<FlightStatusTransition>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


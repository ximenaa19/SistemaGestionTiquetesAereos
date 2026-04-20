using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStatusTransitions.Application.UseCases;

public class GetFlightStatusTransitionByIdUseCase
{
    private readonly IFlightStatusTransitionRepository _repository;

    public GetFlightStatusTransitionByIdUseCase(IFlightStatusTransitionRepository repository)
    {
        _repository = repository;
    }

    public Task<FlightStatusTransition?> ExecuteAsync(int id)
    {
        var idVO = FlightStatusTransitionId.Create(id);
        return _repository.GetByIdAsync(idVO);
    }
}


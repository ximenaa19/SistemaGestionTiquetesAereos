using GestionAerolineas.src.Modules.FlightStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStates.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStates.Application.UseCases;

public class GetFlightStateByNameUseCase
{
    private readonly IFlightStateRepository _repository;

    public GetFlightStateByNameUseCase(IFlightStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<FlightState?> ExecuteAsync(string name)
    {
        var nameVO = FlightStateName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}

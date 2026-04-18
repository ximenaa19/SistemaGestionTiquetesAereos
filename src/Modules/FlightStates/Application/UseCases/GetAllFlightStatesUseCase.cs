using GestionAerolineas.src.Modules.FlightStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStates.Domain.Repositories;

namespace GestionAerolineas.src.Modules.FlightStates.Application.UseCases;

public class GetAllFlightStatesUseCase
{
    private readonly IFlightStateRepository _repository;

    public GetAllFlightStatesUseCase(IFlightStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FlightState>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

using GestionAerolineas.src.Modules.FlightStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStates.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStates.Application.UseCases;

public class GetFlightStateByIdUseCase
{
    private readonly IFlightStateRepository _repository;

    public GetFlightStateByIdUseCase(IFlightStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<FlightState?> ExecuteAsync(int id)
    {
        var idVO = FlightStateId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}

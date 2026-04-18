using GestionAerolineas.src.Modules.FlightStates.Application.Interfaces;
using GestionAerolineas.src.Modules.FlightStates.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStates.Application.Services;

public class FlightStateValidator : IFlightStateValidator
{
    private readonly IFlightStateRepository _repository;

    public FlightStateValidator(IFlightStateRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(FlightStateName name, FlightStateId? currentId = null)
    {
        var normalizedCandidate = FlightStateName.Normalize(name.Value);
        var all = await _repository.GetAllAsync();

        foreach (var item in all)
        {
            if (currentId != null && item.Id.Value == currentId.Value)
                continue;

            if (FlightStateName.Normalize(item.Name.Value) == normalizedCandidate)
                throw new Exception("Ya existe un estado de vuelo con ese nombre");
        }
    }
}

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
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe un estado de vuelo con ese nombre");
    }
}

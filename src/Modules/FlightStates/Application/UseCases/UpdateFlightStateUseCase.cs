using GestionAerolineas.src.Modules.FlightStates.Application.Interfaces;
using GestionAerolineas.src.Modules.FlightStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStates.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStates.Application.UseCases;

public class UpdateFlightStateUseCase
{
    private readonly IFlightStateRepository _repository;
    private readonly IFlightStateValidator _validator;

    public UpdateFlightStateUseCase(
        IFlightStateRepository repository,
        IFlightStateValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string name)
    {
        var idVO = FlightStateId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
            throw new Exception("El estado de vuelo no existe");

        var nameVO = FlightStateName.Create(name);

        await _validator.ValidateNameAsync(nameVO, idVO);

        var updated = FlightState.Create(idVO, nameVO);

        await _repository.UpdateAsync(updated);
    }
}

using GestionAerolineas.src.Modules.FlightStates.Application.Interfaces;
using GestionAerolineas.src.Modules.FlightStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStates.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStates.Application.UseCases;

public class CreateFlightStateUseCase
{
    private readonly IFlightStateRepository _repository;
    private readonly IFlightStateValidator _validator;

    public CreateFlightStateUseCase(
        IFlightStateRepository repository,
        IFlightStateValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var nameVO = FlightStateName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = FlightState.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}

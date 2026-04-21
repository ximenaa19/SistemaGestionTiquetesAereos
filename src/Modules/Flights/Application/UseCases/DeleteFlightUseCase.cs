using GestionAerolineas.src.Modules.Flights.Domain.Repositories;
using GestionAerolineas.src.Modules.Flights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Flights.Application.UseCases;

public class DeleteFlightUseCase
{
    private readonly IFlightRepository _repository;

    public DeleteFlightUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(FlightId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


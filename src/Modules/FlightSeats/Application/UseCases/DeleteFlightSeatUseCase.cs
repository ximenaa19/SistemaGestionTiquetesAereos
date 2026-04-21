using GestionAerolineas.src.Modules.FlightSeats.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightSeats.Application.UseCases;

public class DeleteFlightSeatUseCase
{
    private readonly IFlightSeatRepository _repository;

    public DeleteFlightSeatUseCase(IFlightSeatRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(FlightSeatId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


using GestionAerolineas.src.Modules.Flights.Domain.Aggregate;
using GestionAerolineas.src.Modules.Flights.Domain.Repositories;
using GestionAerolineas.src.Modules.Flights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Flights.Application.UseCases;

public class GetFlightByIdUseCase
{
    private readonly IFlightRepository _repository;

    public GetFlightByIdUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<Flight?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(FlightId.Create(id));
    }
}


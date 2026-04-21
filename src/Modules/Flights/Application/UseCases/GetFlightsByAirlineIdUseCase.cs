using GestionAerolineas.src.Modules.Flights.Domain.Aggregate;
using GestionAerolineas.src.Modules.Flights.Domain.Repositories;
using GestionAerolineas.src.Modules.Flights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Flights.Application.UseCases;

public class GetFlightsByAirlineIdUseCase
{
    private readonly IFlightRepository _repository;

    public GetFlightsByAirlineIdUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Flight>> ExecuteAsync(int airlineId)
    {
        return _repository.GetByAirlineIdAsync(FlightAirlineId.Create(airlineId));
    }
}


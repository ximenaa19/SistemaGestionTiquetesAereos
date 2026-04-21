using GestionAerolineas.src.Modules.Flights.Domain.Aggregate;
using GestionAerolineas.src.Modules.Flights.Domain.Repositories;
using GestionAerolineas.src.Modules.Flights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Flights.Application.UseCases;

public class GetFlightsByRouteIdUseCase
{
    private readonly IFlightRepository _repository;

    public GetFlightsByRouteIdUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Flight>> ExecuteAsync(int routeId)
    {
        return _repository.GetByRouteIdAsync(FlightRouteId.Create(routeId));
    }
}


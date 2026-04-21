using GestionAerolineas.src.Modules.Flights.Domain.Aggregate;
using GestionAerolineas.src.Modules.Flights.Domain.Repositories;
using GestionAerolineas.src.Modules.Flights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Flights.Application.UseCases;

public class GetFlightsByStateIdUseCase
{
    private readonly IFlightRepository _repository;

    public GetFlightsByStateIdUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Flight>> ExecuteAsync(int stateId)
    {
        return _repository.GetByStateIdAsync(FlightStateId.Create(stateId));
    }
}


using GestionAerolineas.src.Modules.Flights.Domain.Aggregate;
using GestionAerolineas.src.Modules.Flights.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Flights.Application.UseCases;

public class GetAllFlightsUseCase
{
    private readonly IFlightRepository _repository;

    public GetAllFlightsUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Flight>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


using GestionAerolineas.src.Modules.Flights.Domain.Aggregate;
using GestionAerolineas.src.Modules.Flights.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Flights.Application.UseCases;

public class GetFlightsByDateRangeUseCase
{
    private readonly IFlightRepository _repository;

    public GetFlightsByDateRangeUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Flight>> ExecuteAsync(DateTime fromInclusive, DateTime toInclusive)
    {
        return _repository.GetByDepartureDateRangeAsync(fromInclusive, toInclusive);
    }
}


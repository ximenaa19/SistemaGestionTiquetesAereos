using GestionAerolineas.src.Modules.Flights.Domain.Aggregate;
using GestionAerolineas.src.Modules.Flights.Domain.Repositories;
using GestionAerolineas.src.Modules.Flights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Flights.Application.UseCases;

public class GetFlightByCodeUseCase
{
    private readonly IFlightRepository _repository;

    public GetFlightByCodeUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<Flight?> ExecuteAsync(string code)
    {
        return _repository.GetByCodeAsync(FlightCode.Create(code));
    }
}


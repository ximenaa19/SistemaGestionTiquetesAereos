using GestionAerolineas.src.Modules.Airports.Domain.Aggregate;
using GestionAerolineas.src.Modules.Airports.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Airports.Application.UseCases;

public class GetAllAirportsUseCase
{
    private readonly IAirportRepository _repository;

    public GetAllAirportsUseCase(IAirportRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Airport>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

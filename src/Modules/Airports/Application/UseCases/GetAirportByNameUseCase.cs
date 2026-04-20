using GestionAerolineas.src.Modules.Airports.Domain.Aggregate;
using GestionAerolineas.src.Modules.Airports.Domain.Repositories;
using GestionAerolineas.src.Modules.Airports.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airports.Application.UseCases;

public class GetAirportByNameUseCase
{
    private readonly IAirportRepository _repository;

    public GetAirportByNameUseCase(IAirportRepository repository)
    {
        _repository = repository;
    }

    public Task<Airport?> ExecuteAsync(string name)
    {
        return _repository.GetByNameAsync(AirportName.Create(name));
    }
}

using GestionAerolineas.src.Modules.Airports.Domain.Aggregate;
using GestionAerolineas.src.Modules.Airports.Domain.Repositories;
using GestionAerolineas.src.Modules.Airports.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airports.Application.UseCases;

public class GetAirportByIdUseCase
{
    private readonly IAirportRepository _repository;

    public GetAirportByIdUseCase(IAirportRepository repository)
    {
        _repository = repository;
    }

    public Task<Airport?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(AirportId.Create(id));
    }
}

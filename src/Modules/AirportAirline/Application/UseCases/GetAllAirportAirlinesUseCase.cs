using GestionAerolineas.src.Modules.AirportAirline.Domain.Aggregate;
using GestionAerolineas.src.Modules.AirportAirline.Domain.Repositories;

namespace GestionAerolineas.src.Modules.AirportAirline.Application.UseCases;

public class GetAllAirportAirlinesUseCase
{
    private readonly IAirportAirlineRepository _repository;

    public GetAllAirportAirlinesUseCase(IAirportAirlineRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<AirportAirlineRelation>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


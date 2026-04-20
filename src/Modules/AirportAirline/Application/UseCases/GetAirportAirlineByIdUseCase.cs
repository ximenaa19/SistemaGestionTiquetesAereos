using GestionAerolineas.src.Modules.AirportAirline.Domain.Aggregate;
using GestionAerolineas.src.Modules.AirportAirline.Domain.Repositories;
using GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AirportAirline.Application.UseCases;

public class GetAirportAirlineByIdUseCase
{
    private readonly IAirportAirlineRepository _repository;

    public GetAirportAirlineByIdUseCase(IAirportAirlineRepository repository)
    {
        _repository = repository;
    }

    public Task<AirportAirlineRelation?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(AirportAirlineId.Create(id));
    }
}


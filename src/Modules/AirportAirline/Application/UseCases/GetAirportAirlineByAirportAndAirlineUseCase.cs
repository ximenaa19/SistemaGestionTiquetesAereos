using GestionAerolineas.src.Modules.AirportAirline.Domain.Aggregate;
using GestionAerolineas.src.Modules.AirportAirline.Domain.Repositories;
using GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AirportAirline.Application.UseCases;

public class GetAirportAirlineByAirportAndAirlineUseCase
{
    private readonly IAirportAirlineRepository _repository;

    public GetAirportAirlineByAirportAndAirlineUseCase(IAirportAirlineRepository repository)
    {
        _repository = repository;
    }

    public Task<AirportAirlineRelation?> ExecuteAsync(int airportId, int airlineId)
    {
        return _repository.GetByAirportAndAirlineAsync(
            AirportAirlineAirportId.Create(airportId),
            AirportAirlineAirlineId.Create(airlineId)
        );
    }
}


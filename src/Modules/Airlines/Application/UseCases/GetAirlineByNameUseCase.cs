using GestionAerolineas.src.Modules.Airlines.Domain.Aggregate;
using GestionAerolineas.src.Modules.Airlines.Domain.Repositories;
using GestionAerolineas.src.Modules.Airlines.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airlines.Application.UseCases;

public class GetAirlineByNameUseCase
{
    private readonly IAirlineRepository _repository;

    public GetAirlineByNameUseCase(IAirlineRepository repository)
    {
        _repository = repository;
    }

    public Task<Airline?> ExecuteAsync(string name)
    {
        return _repository.GetByNameAsync(AirlineName.Create(name));
    }
}


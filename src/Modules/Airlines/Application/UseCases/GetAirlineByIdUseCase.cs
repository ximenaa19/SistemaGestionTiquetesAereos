using GestionAerolineas.src.Modules.Airlines.Domain.Aggregate;
using GestionAerolineas.src.Modules.Airlines.Domain.Repositories;
using GestionAerolineas.src.Modules.Airlines.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airlines.Application.UseCases;

public class GetAirlineByIdUseCase
{
    private readonly IAirlineRepository _repository;

    public GetAirlineByIdUseCase(IAirlineRepository repository)
    {
        _repository = repository;
    }

    public Task<Airline?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(AirlineId.Create(id));
    }
}


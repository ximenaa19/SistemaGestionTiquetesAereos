using GestionAerolineas.src.Modules.Airlines.Domain.Aggregate;
using GestionAerolineas.src.Modules.Airlines.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Airlines.Application.UseCases;

public class GetAllAirlinesUseCase
{
    private readonly IAirlineRepository _repository;

    public GetAllAirlinesUseCase(IAirlineRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Airline>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


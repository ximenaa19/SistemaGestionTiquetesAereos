using GestionAerolineas.src.Modules.Aircraft.Domain.Aggregate;
using GestionAerolineas.src.Modules.Aircraft.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Aircraft.Application.UseCases;

public class GetAllAircraftUseCase
{
    private readonly IAircraftRepository _repository;

    public GetAllAircraftUseCase(IAircraftRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<AircraftAggregate>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


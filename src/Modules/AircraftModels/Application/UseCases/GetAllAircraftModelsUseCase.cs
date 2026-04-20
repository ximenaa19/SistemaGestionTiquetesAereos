using GestionAerolineas.src.Modules.AircraftModels.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftModels.Domain.Repositories;

namespace GestionAerolineas.src.Modules.AircraftModels.Application.UseCases;

public class GetAllAircraftModelsUseCase
{
    private readonly IAircraftModelRepository _repository;

    public GetAllAircraftModelsUseCase(IAircraftModelRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<AircraftModel>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


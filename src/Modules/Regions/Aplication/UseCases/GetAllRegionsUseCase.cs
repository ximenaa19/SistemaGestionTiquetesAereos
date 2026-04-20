using GestionAerolineas.src.Modules.Regions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Regions.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Regions.Application.UseCases;

public class GetAllRegionsUseCase
{
    private readonly IRegionRepository _repository;

    public GetAllRegionsUseCase(IRegionRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Region>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


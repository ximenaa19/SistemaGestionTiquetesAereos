using GestionAerolineas.src.Modules.Regions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Regions.Domain.Repositories;
using GestionAerolineas.src.Modules.Regions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Regions.Application.UseCases;

public class GetRegionByNameUseCase
{
    private readonly IRegionRepository _repository;

    public GetRegionByNameUseCase(IRegionRepository repository)
    {
        _repository = repository;
    }

    public Task<Region?> ExecuteAsync(string name)
    {
        return _repository.GetByNameAsync(RegionName.Create(name));
    }
}


using GestionAerolineas.src.Modules.Regions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Regions.Domain.Repositories;
using GestionAerolineas.src.Modules.Regions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Regions.Application.UseCases;

public class GetRegionByIdUseCase
{
    private readonly IRegionRepository _repository;

    public GetRegionByIdUseCase(IRegionRepository repository)
    {
        _repository = repository;
    }

    public Task<Region?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(RegionId.Create(id));
    }
}


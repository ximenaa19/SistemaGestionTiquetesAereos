using GestionAerolineas.src.Modules.Regions.Domain.Repositories;
using GestionAerolineas.src.Modules.Regions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Regions.Application.UseCases;

public class DeleteRegionUseCase
{
    private readonly IRegionRepository _repository;

    public DeleteRegionUseCase(IRegionRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(RegionId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


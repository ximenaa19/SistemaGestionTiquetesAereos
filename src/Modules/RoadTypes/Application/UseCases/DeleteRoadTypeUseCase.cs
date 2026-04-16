using GestionAerolineas.src.Modules.RoadTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RoadTypes.Application.UseCases;

public class DeleteRoadTypeUseCase
{
    private readonly IRoadTypeRepository _repository;

    public DeleteRoadTypeUseCase(IRoadTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var roadTypeId = RoadTypeId.Create(id);
        var roadType = await _repository.GetByIdAsync(roadTypeId);

        if (roadType is null)
        {
            throw new KeyNotFoundException($"RoadType con id '{roadTypeId.Value}' no existe.");
        }

        await _repository.DeleteAsync(roadType);
    }
}
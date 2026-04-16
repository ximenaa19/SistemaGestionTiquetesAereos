using GestionAerolineas.src.Modules.RoadTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RoadTypes.Application.UseCases;

public class CreateRoadTypeUseCase
{
    private readonly IRoadTypeRepository _repository;

    public CreateRoadTypeUseCase(IRoadTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id, string name)
    {
        var roadType = RoadType.Create(
            RoadTypeId.Create(id),
            RoadTypeName.Create(name)
        );

        await _repository.AddAsync(roadType);
    }
}
using System;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;


namespace GestionAerolineas.src.Modules.RoadTypes.Application.UseCases;

public class UpdateRoadTypeUseCase
{ private readonly IRoadTypeRepository _repository;

    public UpdateRoadTypeUseCase(IRoadTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id, string name)
    {
        var roadType = await _repository.GetByIdAsync(RoadTypeId.Create(id));

        if (roadType == null)
            throw new Exception("RoadType no encontrado");

        // recreas porque tu aggregate es anémico
        var updated = RoadType.Create(
            RoadTypeId.Create(id),
            RoadTypeName.Create(name)
        );

        await _repository.UpdateAsync(updated);
    }

}

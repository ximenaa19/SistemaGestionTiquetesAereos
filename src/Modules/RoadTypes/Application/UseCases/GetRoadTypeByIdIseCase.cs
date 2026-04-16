using System;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RoadTypes.Application.UseCases;

public class GetRoadTypeByIdUseCase
{
    private readonly IRoadTypeRepository _repository;

    public GetRoadTypeByIdUseCase(IRoadTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<RoadType?> ExecuteAsync(int id)
    {
        return await _repository.GetByIdAsync(RoadTypeId.Create(id));
    }
}

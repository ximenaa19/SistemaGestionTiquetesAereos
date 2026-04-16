using System;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;


namespace GestionAerolineas.src.Modules.RoadTypes.Application.UseCases;

public class GetAllRoadTypesUseCase
{
     private readonly IRoadTypeRepository _repository;

    public GetAllRoadTypesUseCase(IRoadTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RoadType>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }

}

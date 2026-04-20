using GestionAerolineas.src.Modules.AircraftModels.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftModels.Domain.Repositories;
using GestionAerolineas.src.Modules.AircraftModels.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftModels.Application.UseCases;

public class GetAircraftModelByNameUseCase
{
    private readonly IAircraftModelRepository _repository;

    public GetAircraftModelByNameUseCase(IAircraftModelRepository repository)
    {
        _repository = repository;
    }

    public Task<AircraftModel?> ExecuteAsync(string modelName)
    {
        var nameVO = AircraftModelName.Create(modelName);
        return _repository.GetByNameAsync(nameVO);
    }
}


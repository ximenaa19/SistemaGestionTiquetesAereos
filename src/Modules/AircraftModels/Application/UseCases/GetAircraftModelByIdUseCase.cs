using GestionAerolineas.src.Modules.AircraftModels.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftModels.Domain.Repositories;
using GestionAerolineas.src.Modules.AircraftModels.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftModels.Application.UseCases;

public class GetAircraftModelByIdUseCase
{
    private readonly IAircraftModelRepository _repository;

    public GetAircraftModelByIdUseCase(IAircraftModelRepository repository)
    {
        _repository = repository;
    }

    public Task<AircraftModel?> ExecuteAsync(int id)
    {
        var idVO = AircraftModelId.Create(id);
        return _repository.GetByIdAsync(idVO);
    }
}


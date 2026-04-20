using GestionAerolineas.src.Modules.Aircraft.Domain.Repositories;
using GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Aircraft.Application.UseCases;

public class DeleteAircraftUseCase
{
    private readonly IAircraftRepository _repository;

    public DeleteAircraftUseCase(IAircraftRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(AircraftId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


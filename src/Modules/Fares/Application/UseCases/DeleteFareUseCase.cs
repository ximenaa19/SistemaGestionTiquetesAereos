using GestionAerolineas.src.Modules.Fares.Domain.Repositories;
using GestionAerolineas.src.Modules.Fares.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Fares.Application.UseCases;

public class DeleteFareUseCase
{
    private readonly IFareRepository _repository;

    public DeleteFareUseCase(IFareRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(FareId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


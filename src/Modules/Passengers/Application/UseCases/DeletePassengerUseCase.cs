using GestionAerolineas.src.Modules.Passengers.Domain.Repositories;
using GestionAerolineas.src.Modules.Passengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Passengers.Application.UseCases;

public class DeletePassengerUseCase
{
    private readonly IPassengerRepository _repository;

    public DeletePassengerUseCase(IPassengerRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(PassengerId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}

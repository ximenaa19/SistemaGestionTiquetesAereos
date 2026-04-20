using GestionAerolineas.src.Modules.Airlines.Domain.Repositories;
using GestionAerolineas.src.Modules.Airlines.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airlines.Application.UseCases;

public class DeleteAirlineUseCase
{
    private readonly IAirlineRepository _repository;

    public DeleteAirlineUseCase(IAirlineRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(AirlineId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


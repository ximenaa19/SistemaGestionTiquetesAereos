using GestionAerolineas.src.Modules.Cities.Domain.Repositories;
using GestionAerolineas.src.Modules.Cities.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Cities.Application.UseCases;

public class DeleteCityUseCase
{
    private readonly ICityRepository _repository;

    public DeleteCityUseCase(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(CityId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}

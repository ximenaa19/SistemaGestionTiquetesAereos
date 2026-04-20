using GestionAerolineas.src.Modules.Cities.Domain.Aggregate;
using GestionAerolineas.src.Modules.Cities.Domain.Repositories;
using GestionAerolineas.src.Modules.Cities.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Cities.Application.UseCases;

public class GetCityByNameUseCase
{
    private readonly ICityRepository _repository;

    public GetCityByNameUseCase(ICityRepository repository)
    {
        _repository = repository;
    }

    public Task<City?> ExecuteAsync(string name)
    {
        return _repository.GetByNameAsync(CityName.Create(name));
    }
}

using GestionAerolineas.src.Modules.Cities.Domain.Aggregate;
using GestionAerolineas.src.Modules.Cities.Domain.Repositories;
using GestionAerolineas.src.Modules.Cities.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Cities.Application.UseCases;

public class GetCityByIdUseCase
{
    private readonly ICityRepository _repository;

    public GetCityByIdUseCase(ICityRepository repository)
    {
        _repository = repository;
    }

    public Task<City?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(CityId.Create(id));
    }
}

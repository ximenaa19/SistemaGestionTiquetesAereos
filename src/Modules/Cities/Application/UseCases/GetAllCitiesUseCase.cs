using GestionAerolineas.src.Modules.Cities.Domain.Aggregate;
using GestionAerolineas.src.Modules.Cities.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Cities.Application.UseCases;

public class GetAllCitiesUseCase
{
    private readonly ICityRepository _repository;

    public GetAllCitiesUseCase(ICityRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<City>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

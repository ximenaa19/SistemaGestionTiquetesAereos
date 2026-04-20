using GestionAerolineas.src.Modules.Countries.Domain.Aggregate;
using GestionAerolineas.src.Modules.Countries.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Countries.Application.UseCases;

public class GetAllCountriesUseCase
{
    private readonly ICountryRepository _repository;

    public GetAllCountriesUseCase(ICountryRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Country>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


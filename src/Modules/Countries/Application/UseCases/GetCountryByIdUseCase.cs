using GestionAerolineas.src.Modules.Countries.Domain.Aggregate;
using GestionAerolineas.src.Modules.Countries.Domain.Repositories;
using GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Countries.Application.UseCases;

public class GetCountryByIdUseCase
{
    private readonly ICountryRepository _repository;

    public GetCountryByIdUseCase(ICountryRepository repository)
    {
        _repository = repository;
    }

    public Task<Country?> ExecuteAsync(int id)
    {
        var idVO = CountryId.Create(id);
        return _repository.GetByIdAsync(idVO);
    }
}


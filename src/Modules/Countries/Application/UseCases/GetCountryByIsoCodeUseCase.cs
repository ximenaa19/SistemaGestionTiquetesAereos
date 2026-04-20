using GestionAerolineas.src.Modules.Countries.Domain.Aggregate;
using GestionAerolineas.src.Modules.Countries.Domain.Repositories;
using GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Countries.Application.UseCases;

public class GetCountryByIsoCodeUseCase
{
    private readonly ICountryRepository _repository;

    public GetCountryByIsoCodeUseCase(ICountryRepository repository)
    {
        _repository = repository;
    }

    public Task<Country?> ExecuteAsync(string isoCode)
    {
        var isoVO = CountryCodigoIso.Create(isoCode);
        return _repository.GetByIsoCodeAsync(isoVO);
    }
}


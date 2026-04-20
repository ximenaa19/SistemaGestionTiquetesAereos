using GestionAerolineas.src.Modules.Countries.Application.Interfaces;
using GestionAerolineas.src.Modules.Countries.Domain.Aggregate;
using GestionAerolineas.src.Modules.Countries.Domain.Repositories;
using GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Countries.Application.UseCases;

public class UpdateCountryUseCase
{
    private readonly ICountryRepository _repository;
    private readonly ICountryValidator _validator;

    public UpdateCountryUseCase(ICountryRepository repository, ICountryValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string name, string isoCode, int continentId)
    {
        var idVO = CountryId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);
        if (existing is null)
            throw new Exception("El país no existe");

        var nameVO = CountryName.Create(name);
        var isoVO = CountryCodigoIso.Create(isoCode);
        var continentVO = CountryContinentId.Create(continentId);

        await _validator.ValidateContinentExistsAsync(continentVO);
        await _validator.ValidateIsoCodeAsync(isoVO, idVO);

        var updated = Country.Create(idVO, nameVO, isoVO, continentVO);

        await _repository.UpdateAsync(updated);
    }
}


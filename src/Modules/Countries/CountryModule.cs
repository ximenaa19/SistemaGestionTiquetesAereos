using GestionAerolineas.src.Modules.Continents.Application.UseCases;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Countries.Application.Interfaces;
using GestionAerolineas.src.Modules.Countries.Application.Services;
using GestionAerolineas.src.Modules.Countries.Application.UseCases;
using GestionAerolineas.src.Modules.Countries.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Countries.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Countries;

public static class CountryModule
{
    public static CountryMenu Build(AppDbContext context)
    {
        var repository = new CountryRepository(context);

        var continentRepository = new ContinentRepository(context);
        ICountryValidator validator = new CountryValidator(repository, continentRepository);

        var create = new CreateCountryUseCase(repository, validator);
        var getAll = new GetAllCountriesUseCase(repository);
        var getById = new GetCountryByIdUseCase(repository);
        var getByName = new GetCountryByNameUseCase(repository);
        var getByIso = new GetCountryByIsoCodeUseCase(repository);
        var update = new UpdateCountryUseCase(repository, validator);
        var delete = new DeleteCountryUseCase(repository);

        var getAllContinents = new GetAllContinentsUseCase(continentRepository);

        return new CountryMenu(
            create,
            getAll,
            getById,
            getByName,
            getByIso,
            update,
            delete,
            getAllContinents
        );
    }
}


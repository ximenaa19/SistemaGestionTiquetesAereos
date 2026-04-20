using GestionAerolineas.src.Modules.Airlines.Application.Interfaces;
using GestionAerolineas.src.Modules.Airlines.Application.Services;
using GestionAerolineas.src.Modules.Airlines.Application.UseCases;
using GestionAerolineas.src.Modules.Airlines.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Airlines.UI;
using GestionAerolineas.src.Modules.Countries.Application.UseCases;
using GestionAerolineas.src.Modules.Countries.Infrastructure.Repository;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Airlines;

public static class AirlineModule
{
    public static AirlineMenu Build(AppDbContext context)
    {
        var repository = new AirlineRepository(context);

        var countryRepository = new CountryRepository(context);
        IAirlineValidator validator = new AirlineValidator(repository, countryRepository);

        var create = new CreateAirlineUseCase(repository, validator);
        var getAll = new GetAllAirlinesUseCase(repository);
        var getById = new GetAirlineByIdUseCase(repository);
        var getByName = new GetAirlineByNameUseCase(repository);
        var update = new UpdateAirlineUseCase(repository, validator);
        var delete = new DeleteAirlineUseCase(repository);

        var getAllCountries = new GetAllCountriesUseCase(countryRepository);

        return new AirlineMenu(create, getAll, getById, getByName, update, delete, getAllCountries);
    }
}


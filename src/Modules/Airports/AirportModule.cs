using GestionAerolineas.src.Modules.Airports.Application.Interfaces;
using GestionAerolineas.src.Modules.Airports.Application.Services;
using GestionAerolineas.src.Modules.Airports.Application.UseCases;
using GestionAerolineas.src.Modules.Airports.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Airports.UI;
using GestionAerolineas.src.Modules.Cities.Application.UseCases;
using GestionAerolineas.src.Modules.Cities.Infrastructure.Repository;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Airports;

public static class AirportModule
{
    public static AirportMenu Build(AppDbContext context)
    {
        var repository = new AirportRepository(context);

        var cityRepository = new CityRepository(context);
        IAirportValidator validator = new AirportValidator(repository, cityRepository);

        var create = new CreateAirportUseCase(repository, validator);
        var getAll = new GetAllAirportsUseCase(repository);
        var getById = new GetAirportByIdUseCase(repository);
        var getByName = new GetAirportByNameUseCase(repository);
        var update = new UpdateAirportUseCase(repository, validator);
        var delete = new DeleteAirportUseCase(repository);

        var getAllCities = new GetAllCitiesUseCase(cityRepository);

        return new AirportMenu(create, getAll, getById, getByName, update, delete, getAllCities);
    }
}

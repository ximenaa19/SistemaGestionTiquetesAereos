using GestionAerolineas.src.Modules.Aircraft.Application.Interfaces;
using GestionAerolineas.src.Modules.Aircraft.Application.Services;
using GestionAerolineas.src.Modules.Aircraft.Application.UseCases;
using GestionAerolineas.src.Modules.Aircraft.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Aircraft.UI;
using GestionAerolineas.src.Modules.AircraftModels.Application.UseCases;
using GestionAerolineas.src.Modules.AircraftModels.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Airlines.Application.UseCases;
using GestionAerolineas.src.Modules.Airlines.Infrastructure.Repository;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Aircraft;

public static class AircraftModule
{
    public static AircraftMenu Build(AppDbContext context)
    {
        var repository = new AircraftRepository(context);

        var aircraftModelRepository = new AircraftModelRepository(context);
        var airlineRepository = new AirlineRepository(context);
        IAircraftValidator validator = new AircraftValidator(repository, aircraftModelRepository, airlineRepository);

        var create = new CreateAircraftUseCase(repository, validator);
        var getAll = new GetAllAircraftUseCase(repository);
        var getById = new GetAircraftByIdUseCase(repository);
        var getByRegistration = new GetAircraftByRegistrationUseCase(repository);
        var update = new UpdateAircraftUseCase(repository, validator);
        var delete = new DeleteAircraftUseCase(repository);

        var getAllModels = new GetAllAircraftModelsUseCase(aircraftModelRepository);
        var getAllAirlines = new GetAllAirlinesUseCase(airlineRepository);

        return new AircraftMenu(
            create,
            getAll,
            getById,
            getByRegistration,
            update,
            delete,
            getAllModels,
            getAllAirlines
        );
    }
}


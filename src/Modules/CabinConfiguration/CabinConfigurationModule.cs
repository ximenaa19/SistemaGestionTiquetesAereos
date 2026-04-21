using GestionAerolineas.src.Modules.Aircraft.Application.UseCases;
using GestionAerolineas.src.Modules.Aircraft.Infrastructure.Repository;
using GestionAerolineas.src.Modules.CabinConfiguration.Application.Interfaces;
using GestionAerolineas.src.Modules.CabinConfiguration.Application.Services;
using GestionAerolineas.src.Modules.CabinConfiguration.Application.UseCases;
using GestionAerolineas.src.Modules.CabinConfiguration.Infrastructure.Repository;
using GestionAerolineas.src.Modules.CabinConfiguration.UI;
using GestionAerolineas.src.Modules.CabinTypes.Application.UseCases;
using GestionAerolineas.src.Modules.CabinTypes.Infrastructure.Repository;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.CabinConfiguration;

public static class CabinConfigurationModule
{
    public static CabinConfigurationMenu Build(AppDbContext context)
    {
        var repository = new CabinConfigurationRepository(context);

        var aircraftRepository = new AircraftRepository(context);
        var cabinTypeRepository = new CabinTypeRepository(context);

        ICabinConfigurationValidator validator = new CabinConfigurationValidator(repository, aircraftRepository, cabinTypeRepository);

        var create = new CreateCabinConfigurationUseCase(repository, validator);
        var getAll = new GetAllCabinConfigurationsUseCase(repository);
        var getById = new GetCabinConfigurationByIdUseCase(repository);
        var getByAircraftId = new GetCabinConfigurationsByAircraftIdUseCase(repository);
        var getByAircraftAndCabinType = new GetCabinConfigurationByAircraftAndCabinTypeUseCase(repository);
        var update = new UpdateCabinConfigurationUseCase(repository, validator);
        var delete = new DeleteCabinConfigurationUseCase(repository);

        var getAllAircraft = new GetAllAircraftUseCase(aircraftRepository);
        var getAllCabinTypes = new GetAllCabinTypeUseCase(cabinTypeRepository);

        return new CabinConfigurationMenu(
            create,
            getAll,
            getById,
            getByAircraftId,
            getByAircraftAndCabinType,
            update,
            delete,
            getAllAircraft,
            getAllCabinTypes
        );
    }
}


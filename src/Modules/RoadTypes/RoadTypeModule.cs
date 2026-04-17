using GestionAerolineas.src.Modules.RoadTypes.Infrastructure.Repository;
using GestionAerolineas.src.Modules.RoadTypes.Application.Services;
using GestionAerolineas.src.Modules.RoadTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.RoadTypes.Application.UseCases;
using GestionAerolineas.src.Modules.RoadTypes.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.RoadTypes;

public static class RoadTypeModule
{
    public static RoadTypeMenu Build(AppDbContext context)
    {
        var repository = new RoadTypeRepository(context);
        IRoadTypeValidator validator = new RoadTypeValidator(repository);

        var create = new CreateRoadTypeUseCase(repository, validator);
        var getAll = new GetAllRoadTypesUseCase(repository);
        var getById = new GetRoadTypeByIdUseCase(repository);
        var getByName = new GetRoadTypeByNameUseCase(repository);
        var update = new UpdateRoadTypeUseCase(repository, validator);
        var delete = new DeleteRoadTypeUseCase(repository);

        return new RoadTypeMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}
using GestionAerolineas.src.Modules.FlightRoles.Application.Interfaces;
using GestionAerolineas.src.Modules.FlightRoles.Application.Services;
using GestionAerolineas.src.Modules.FlightRoles.Application.UseCases;
using GestionAerolineas.src.Modules.FlightRoles.Infrastructure.Repository;
using GestionAerolineas.src.Modules.FlightRoles.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.FlightRoles;

public static class FlightRoleModule
{
    public static FlightRoleMenu Build(AppDbContext context)
    {
        var repository = new FlightRoleRepository(context);
        IFlightRoleValidator validator = new FlightRoleValidator(repository);

        var create = new CreateFlightRoleUseCase(repository, validator);
        var getAll = new GetAllFlightRolesUseCase(repository);
        var getById = new GetFlightRoleByIdUseCase(repository);
        var getByName = new GetFlightRoleByNameUseCase(repository);
        var update = new UpdateFlightRoleUseCase(repository, validator);
        var delete = new DeleteFlightRoleUseCase(repository);

        return new FlightRoleMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}


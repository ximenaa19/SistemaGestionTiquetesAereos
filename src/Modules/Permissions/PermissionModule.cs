using GestionAerolineas.src.Modules.Permissions.Application.Interfaces;
using GestionAerolineas.src.Modules.Permissions.Application.Services;
using GestionAerolineas.src.Modules.Permissions.Application.UseCases;
using GestionAerolineas.src.Modules.Permissions.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Permissions.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Permissions;

public static class PermissionModule
{
    public static PermissionMenu Build(AppDbContext context)
    {
        var repository = new PermissionRepository(context);
        IPermissionValidator validator = new PermissionValidator(repository);

        var create = new CreatePermissionUseCase(repository, validator);
        var getAll = new GetAllPermissionsUseCase(repository);
        var getById = new GetPermissionByIdUseCase(repository);
        var getByName = new GetPermissionByNameUseCase(repository);
        var update = new UpdatePermissionUseCase(repository, validator);
        var delete = new DeletePermissionUseCase(repository);

        return new PermissionMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}

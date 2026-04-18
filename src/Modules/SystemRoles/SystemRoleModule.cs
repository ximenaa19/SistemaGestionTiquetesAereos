using GestionAerolineas.src.Modules.SystemRoles.Application.Interfaces;
using GestionAerolineas.src.Modules.SystemRoles.Application.Services;
using GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;
using GestionAerolineas.src.Modules.SystemRoles.Infrastructure.Repository;
using GestionAerolineas.src.Modules.SystemRoles.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.SystemRoles;

public static class SystemRoleModule
{
    public static SystemRoleMenu Build(AppDbContext context)
    {
        var repository = new SystemRoleRepository(context);
        ISystemRoleValidator validator = new SystemRoleValidator(repository);

        var create = new CreateSystemRoleUseCase(repository, validator);
        var getAll = new GetAllSystemRolesUseCase(repository);
        var getById = new GetSystemRoleByIdUseCase(repository);
        var getByName = new GetSystemRoleByNameUseCase(repository);
        var update = new UpdateSystemRoleUseCase(repository, validator);
        var delete = new DeleteSystemRoleUseCase(repository);

        return new SystemRoleMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}

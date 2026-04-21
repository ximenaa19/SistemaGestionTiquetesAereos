using GestionAerolineas.src.Modules.People.Application.UseCases;
using GestionAerolineas.src.Modules.People.Infrastructure.Repository;
using GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;
using GestionAerolineas.src.Modules.SystemRoles.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Users.Application.Interfaces;
using GestionAerolineas.src.Modules.Users.Application.Services;
using GestionAerolineas.src.Modules.Users.Application.UseCases;
using GestionAerolineas.src.Modules.Users.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Users.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Users;

public static class UserModule
{
    public static UserMenu Build(AppDbContext context)
    {
        var repository = new UserRepository(context);

        var personRepository = new PersonRepository(context);
        var systemRoleRepository = new SystemRoleRepository(context);

        IUserValidator validator = new UserValidator(repository, personRepository, systemRoleRepository);

        var create = new CreateUserUseCase(repository, validator);
        var getAll = new GetAllUsersUseCase(repository);
        var getById = new GetUserByIdUseCase(repository);
        var getByUsername = new GetUserByUsernameUseCase(repository);
        var getByPersonId = new GetUserByPersonIdUseCase(repository);
        var getByRoleId = new GetUsersByRoleIdUseCase(repository);
        var searchByPersonName = new SearchUsersByPersonNameUseCase(repository);
        var getActive = new GetActiveUsersUseCase(repository);
        var getInactive = new GetInactiveUsersUseCase(repository);
        var update = new UpdateUserUseCase(repository, validator);
        var delete = new DeleteUserUseCase(repository);

        var getAllPeople = new GetAllPeopleUseCase(personRepository);
        var getAllRoles = new GetAllSystemRolesUseCase(systemRoleRepository);

        return new UserMenu(
            create,
            getAll,
            getById,
            getByUsername,
            getByPersonId,
            getByRoleId,
            searchByPersonName,
            getActive,
            getInactive,
            update,
            delete,
            getAllPeople,
            getAllRoles);
    }
}

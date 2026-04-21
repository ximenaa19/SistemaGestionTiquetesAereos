using GestionAerolineas.src.Modules.Airlines.Application.UseCases;
using GestionAerolineas.src.Modules.Airlines.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Airports.Application.UseCases;
using GestionAerolineas.src.Modules.Airports.Infrastructure.Repository;
using GestionAerolineas.src.Modules.People.Application.UseCases;
using GestionAerolineas.src.Modules.People.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Staff.Application.Interfaces;
using GestionAerolineas.src.Modules.Staff.Application.Services;
using GestionAerolineas.src.Modules.Staff.Application.UseCases;
using GestionAerolineas.src.Modules.Staff.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Staff.UI;
using GestionAerolineas.src.Modules.StaffRoles.Application.UseCases;
using GestionAerolineas.src.Modules.StaffRoles.Infrastructure.Repository;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Staff;

public static class StaffModule
{
    public static StaffMenu Build(AppDbContext context)
    {
        var repository = new StaffRepository(context);

        var personRepository = new PersonRepository(context);
        var staffRoleRepository = new StaffRoleRepository(context);
        var airlineRepository = new AirlineRepository(context);
        var airportRepository = new AirportRepository(context);

        IStaffValidator validator = new StaffValidator(repository, personRepository, staffRoleRepository, airlineRepository, airportRepository);

        var create = new CreateStaffUseCase(repository, validator);
        var getAll = new GetAllStaffUseCase(repository);
        var getById = new GetStaffByIdUseCase(repository);
        var getByPersonId = new GetStaffByPersonIdUseCase(repository);
        var getByRoleId = new GetStaffByRoleIdUseCase(repository);
        var searchByName = new SearchStaffByPersonNameOrLastNameUseCase(repository);
        var getActive = new GetActiveStaffUseCase(repository);
        var getInactive = new GetInactiveStaffUseCase(repository);
        var update = new UpdateStaffUseCase(repository, validator);
        var delete = new DeleteStaffUseCase(repository);

        var getAllPeople = new GetAllPeopleUseCase(personRepository);
        var getAllStaffRoles = new GetAllStaffRolesUseCase(staffRoleRepository);
        var getAllAirlines = new GetAllAirlinesUseCase(airlineRepository);
        var getAllAirports = new GetAllAirportsUseCase(airportRepository);

        return new StaffMenu(
            create,
            getAll,
            getById,
            getByPersonId,
            getByRoleId,
            searchByName,
            getActive,
            getInactive,
            update,
            delete,
            getAllPeople,
            getAllStaffRoles,
            getAllAirlines,
            getAllAirports);
    }
}


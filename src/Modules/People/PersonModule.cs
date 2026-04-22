using GestionAerolineas.src.Modules.Addresses.Application.UseCases;
using GestionAerolineas.src.Modules.Addresses.Application.Services;
using GestionAerolineas.src.Modules.Addresses.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Cities.Application.UseCases;
using GestionAerolineas.src.Modules.Cities.Infrastructure.Repository;
using GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;
using GestionAerolineas.src.Modules.DocumentTypes.Infrastructure.Repository;
using GestionAerolineas.src.Modules.EmailDomains.Application.UseCases;
using GestionAerolineas.src.Modules.EmailDomains.Infrastructure.Repository;
using GestionAerolineas.src.Modules.People.Application.Interfaces;
using GestionAerolineas.src.Modules.People.Application.Services;
using GestionAerolineas.src.Modules.People.Application.UseCases;
using GestionAerolineas.src.Modules.People.Infrastructure.Repository;
using GestionAerolineas.src.Modules.PersonEmails.Application.Interfaces;
using GestionAerolineas.src.Modules.PersonEmails.Application.Services;
using GestionAerolineas.src.Modules.PersonEmails.Application.UseCases;
using GestionAerolineas.src.Modules.PersonEmails.Infrastructure.Repository;
using GestionAerolineas.src.Modules.RoadTypes.Application.UseCases;
using GestionAerolineas.src.Modules.RoadTypes.Infrastructure.Repository;
using GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;
using GestionAerolineas.src.Modules.SystemRoles.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Users.Application.Interfaces;
using GestionAerolineas.src.Modules.Users.Application.Services;
using GestionAerolineas.src.Modules.Users.Application.UseCases;
using GestionAerolineas.src.Modules.Users.Infrastructure.Repository;
using GestionAerolineas.src.Modules.People.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.People;

public static class PersonModule
{
    public static PersonMenu Build(AppDbContext context)
    {
        var repository = new PersonRepository(context);

        var documentTypeRepository = new DocumentTypeRepository(context);
        var addressRepository = new AddressRepository(context);

        IPersonValidator validator = new PersonValidator(repository, documentTypeRepository, addressRepository);

        var create = new CreatePersonUseCase(repository, validator);
        var getAll = new GetAllPeopleUseCase(repository);
        var getById = new GetPersonByIdUseCase(repository);
        var getByDocument = new GetPersonByDocumentUseCase(repository);
        var update = new UpdatePersonUseCase(repository, validator);
        var delete = new DeletePersonUseCase(repository);

        var getAllDocumentTypes = new GetAllDocumentTypesUseCase(documentTypeRepository);
        var getAllAddresses = new GetAllAddressesUseCase(addressRepository);

        return new PersonMenu(
            create,
            getAll,
            getById,
            getByDocument,
            update,
            delete,
            getAllDocumentTypes,
            getAllAddresses
        );
    }

    public static AdminCreatePersonFlow BuildAdminCreateFlow(AppDbContext context)
    {
        var personRepository = new PersonRepository(context);
        var documentTypeRepository = new DocumentTypeRepository(context);
        var addressRepository = new AddressRepository(context);
        var roadTypeRepository = new RoadTypeRepository(context);
        var cityRepository = new CityRepository(context);

        IPersonValidator personValidator = new PersonValidator(personRepository, documentTypeRepository, addressRepository);
        var createPerson = new CreatePersonUseCase(personRepository, personValidator);
        var getPersonByDocument = new GetPersonByDocumentUseCase(personRepository);
        var getAllDocumentTypes = new GetAllDocumentTypesUseCase(documentTypeRepository);
        var getAllAddresses = new GetAllAddressesUseCase(addressRepository);
        var createAddress = new CreateAddressUseCase(addressRepository, new AddressValidator(roadTypeRepository, cityRepository));
        var getAllRoadTypes = new GetAllRoadTypesUseCase(roadTypeRepository);
        var getAllCities = new GetAllCitiesUseCase(cityRepository);

        var personEmailRepository = new PersonEmailRepository(context);
        var emailDomainRepository = new EmailDomainRepository(context);
        IPersonEmailValidator personEmailValidator = new PersonEmailValidator(personEmailRepository, personRepository, emailDomainRepository);

        var createPersonEmail = new CreatePersonEmailUseCase(personEmailRepository, personEmailValidator);
        var getAllEmailDomains = new GetAllEmailDomainsUseCase(emailDomainRepository);

        var systemRoleRepository = new SystemRoleRepository(context);
        var getAllSystemRoles = new GetAllSystemRolesUseCase(systemRoleRepository);

        var userRepository = new UserRepository(context);
        IUserValidator userValidator = new UserValidator(userRepository, personRepository, systemRoleRepository);
        var createUser = new CreateUserUseCase(userRepository, userValidator);

        return new AdminCreatePersonFlow(
            createPerson,
            getPersonByDocument,
            createPersonEmail,
            getAllDocumentTypes,
            getAllEmailDomains,
            createAddress,
            getAllAddresses,
            getAllRoadTypes,
            getAllCities,
            getAllSystemRoles,
            createUser
        );
    }
}


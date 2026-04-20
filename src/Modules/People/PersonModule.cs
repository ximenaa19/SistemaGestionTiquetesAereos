using GestionAerolineas.src.Modules.Addresses.Application.UseCases;
using GestionAerolineas.src.Modules.Addresses.Infrastructure.Repository;
using GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;
using GestionAerolineas.src.Modules.DocumentTypes.Infrastructure.Repository;
using GestionAerolineas.src.Modules.People.Application.Interfaces;
using GestionAerolineas.src.Modules.People.Application.Services;
using GestionAerolineas.src.Modules.People.Application.UseCases;
using GestionAerolineas.src.Modules.People.Infrastructure.Repository;
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
}


using GestionAerolineas.src.Modules.People.Application.UseCases;
using GestionAerolineas.src.Modules.People.Infrastructure.Repository;
using GestionAerolineas.src.Modules.PersonPhones.Application.Interfaces;
using GestionAerolineas.src.Modules.PersonPhones.Application.Services;
using GestionAerolineas.src.Modules.PersonPhones.Application.UseCases;
using GestionAerolineas.src.Modules.PersonPhones.Infrastructure.Repository;
using GestionAerolineas.src.Modules.PersonPhones.UI;
using GestionAerolineas.src.Modules.PhoneCodes.Application.UseCases;
using GestionAerolineas.src.Modules.PhoneCodes.Infrastructure.Repository;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.PersonPhones;

public static class PersonPhoneModule
{
    public static PersonPhoneMenu Build(AppDbContext context)
    {
        var repository = new PersonPhoneRepository(context);

        var personRepository = new PersonRepository(context);
        var phoneCodeRepository = new PhoneCodeRepository(context);
        IPersonPhoneValidator validator = new PersonPhoneValidator(repository, personRepository, phoneCodeRepository);

        var create = new CreatePersonPhoneUseCase(repository, validator);
        var getAll = new GetAllPersonPhonesUseCase(repository);
        var getById = new GetPersonPhoneByIdUseCase(repository);
        var getByPhone = new GetPersonPhoneByPersonAndPhoneUseCase(repository);
        var update = new UpdatePersonPhoneUseCase(repository, validator);
        var delete = new DeletePersonPhoneUseCase(repository);

        var getAllPeople = new GetAllPeopleUseCase(personRepository);
        var getAllPhoneCodes = new GetAllPhoneCodesUseCase(phoneCodeRepository);

        return new PersonPhoneMenu(
            create,
            getAll,
            getById,
            getByPhone,
            update,
            delete,
            getAllPeople,
            getAllPhoneCodes
        );
    }
}


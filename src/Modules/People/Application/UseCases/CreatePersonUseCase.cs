using GestionAerolineas.src.Modules.People.Application.Interfaces;
using GestionAerolineas.src.Modules.People.Domain.Aggregate;
using GestionAerolineas.src.Modules.People.Domain.Repositories;
using GestionAerolineas.src.Modules.People.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.People.Application.UseCases;

public class CreatePersonUseCase
{
    private readonly IPersonRepository _repository;
    private readonly IPersonValidator _validator;

    public CreatePersonUseCase(IPersonRepository repository, IPersonValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(
        int documentTypeId,
        string documentNumber,
        string firstNames,
        string lastNames,
        DateTime? birthDate,
        string? gender,
        int? addressId)
    {
        var documentTypeVO = PersonDocumentTypeId.Create(documentTypeId);
        var documentNumberVO = PersonDocumentNumber.Create(documentNumber);
        var firstNamesVO = PersonFirstNames.Create(firstNames);
        var lastNamesVO = PersonLastNames.Create(lastNames);
        var birthDateVO = PersonBirthDate.Create(birthDate);
        var genderVO = PersonGender.Create(gender);
        var addressIdVO = PersonAddressId.Create(addressId);

        await _validator.ValidateDocumentTypeExistsAsync(documentTypeVO);
        await _validator.ValidateAddressExistsAsync(addressIdVO);
        await _validator.ValidateUniqueDocumentAsync(documentTypeVO, documentNumberVO);

        var entity = Person.CreateNew(
            documentTypeVO,
            documentNumberVO,
            firstNamesVO,
            lastNamesVO,
            birthDateVO,
            genderVO,
            addressIdVO
        );

        await _repository.AddAsync(entity);
    }
}


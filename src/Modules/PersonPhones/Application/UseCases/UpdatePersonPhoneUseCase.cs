using GestionAerolineas.src.Modules.PersonPhones.Application.Interfaces;
using GestionAerolineas.src.Modules.PersonPhones.Domain.Aggregate;
using GestionAerolineas.src.Modules.PersonPhones.Domain.Repositories;
using GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonPhones.Application.UseCases;

public class UpdatePersonPhoneUseCase
{
    private readonly IPersonPhoneRepository _repository;
    private readonly IPersonPhoneValidator _validator;

    public UpdatePersonPhoneUseCase(IPersonPhoneRepository repository, IPersonPhoneValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, int personId, int phoneCodeId, string phoneNumber, bool isPrimary)
    {
        var idVO = PersonPhoneId.Create(id);
        var personIdVO = PersonPhonePersonId.Create(personId);
        var phoneCodeIdVO = PersonPhoneCodeId.Create(phoneCodeId);
        var phoneNumberVO = PersonPhoneNumber.Create(phoneNumber);
        var primaryVO = PersonPhoneIsPrimary.Create(isPrimary);

        await _validator.ValidatePersonExistsAsync(personIdVO);
        await _validator.ValidatePhoneCodeExistsAsync(phoneCodeIdVO);
        await _validator.ValidateUniquePhoneForPersonAsync(personIdVO, phoneCodeIdVO, phoneNumberVO, idVO);
        await _validator.ValidatePrimaryPhoneAsync(personIdVO, primaryVO, idVO);

        var entity = PersonPhone.Create(idVO, personIdVO, phoneCodeIdVO, phoneNumberVO, primaryVO);
        await _repository.UpdateAsync(entity);
    }
}


using GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonPhones.Application.Interfaces;

public interface IPersonPhoneValidator
{
    Task ValidatePersonExistsAsync(PersonPhonePersonId personId);
    Task ValidatePhoneCodeExistsAsync(PersonPhoneCodeId phoneCodeId);
    Task ValidateUniquePhoneForPersonAsync(PersonPhonePersonId personId, PersonPhoneCodeId phoneCodeId, PersonPhoneNumber phoneNumber, PersonPhoneId? currentId = null);
    Task ValidatePrimaryPhoneAsync(PersonPhonePersonId personId, PersonPhoneIsPrimary isPrimary, PersonPhoneId? currentId = null);
}


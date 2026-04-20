using GestionAerolineas.src.Modules.PersonEmails.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonEmails.Application.Interfaces;

public interface IPersonEmailValidator
{
    Task ValidatePersonExistsAsync(PersonEmailPersonId personId);
    Task ValidateEmailDomainExistsAsync(PersonEmailDomainId emailDomainId);
    Task ValidateUniqueEmailForPersonAsync(PersonEmailPersonId personId, PersonEmailUser user, PersonEmailDomainId emailDomainId, PersonEmailId? currentId = null);
    Task ValidatePrimaryEmailAsync(PersonEmailPersonId personId, PersonEmailIsPrimary isPrimary, PersonEmailId? currentId = null);
}


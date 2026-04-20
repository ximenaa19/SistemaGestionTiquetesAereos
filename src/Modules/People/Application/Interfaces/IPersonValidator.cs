using GestionAerolineas.src.Modules.People.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.People.Application.Interfaces;

public interface IPersonValidator
{
    Task ValidateDocumentTypeExistsAsync(PersonDocumentTypeId documentTypeId);
    Task ValidateAddressExistsAsync(PersonAddressId addressId);
    Task ValidateUniqueDocumentAsync(PersonDocumentTypeId documentTypeId, PersonDocumentNumber documentNumber, PersonId? currentId = null);
}


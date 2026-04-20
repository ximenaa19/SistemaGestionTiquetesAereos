using GestionAerolineas.src.Modules.PersonPhones.Domain.Aggregate;
using GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonPhones.Domain.Repositories;

public interface IPersonPhoneRepository
{
    Task<IEnumerable<PersonPhone>> GetAllAsync();
    Task<PersonPhone?> GetByIdAsync(PersonPhoneId id);
    Task<PersonPhone?> GetByPersonAndCodeAndNumberAsync(PersonPhonePersonId personId, PersonPhoneCodeId phoneCodeId, PersonPhoneNumber phoneNumber);
    Task AddAsync(PersonPhone phone);
    Task UpdateAsync(PersonPhone phone);
    Task DeleteAsync(PersonPhone phone);
    Task<bool> ExistsAsync(PersonPhoneId id);
    Task<bool> ExistsByNormalizedPhoneForPersonAsync(int personId, int phoneCodeId, string normalizedPhoneNumber, int? excludingId = null);
    Task<bool> ExistsPrimaryForPersonAsync(int personId, int? excludingId = null);
}


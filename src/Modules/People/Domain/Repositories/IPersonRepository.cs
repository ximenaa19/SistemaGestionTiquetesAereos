using GestionAerolineas.src.Modules.People.Domain.Aggregate;
using GestionAerolineas.src.Modules.People.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.People.Domain.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person?> GetByIdAsync(PersonId id);
    Task<Person?> GetByDocumentAsync(PersonDocumentTypeId documentTypeId, PersonDocumentNumber documentNumber);
    Task AddAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(Person person);
    Task<bool> ExistsAsync(PersonId id);
    Task<bool> ExistsByNormalizedDocumentInTypeAsync(int documentTypeId, string normalizedDocumentNumber, int? excludingId = null);
}


using GestionAerolineas.src.Modules.EmailDomains.Domain.Aggregate;
using GestionAerolineas.src.Modules.EmailDomains.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.EmailDomains.Domain.Repositories;

public interface IEmailDomainRepository
{
    Task<IEnumerable<EmailDomain>> GetAllAsync();
    Task<EmailDomain?> GetByIdAsync(EmailDomainId id);
    Task<EmailDomain?> GetByDomainAsync(EmailDomainValue domain);
    Task AddAsync(EmailDomain emailDomain);
    Task UpdateAsync(EmailDomain emailDomain);
    Task DeleteAsync(EmailDomain emailDomain);
    Task<bool> ExistsAsync(EmailDomainId id);
}


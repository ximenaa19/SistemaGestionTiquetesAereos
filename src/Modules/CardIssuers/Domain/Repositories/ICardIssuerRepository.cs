using GestionAerolineas.src.Modules.CardIssuers.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardIssuers.Domain.Repositories;

public interface ICardIssuerRepository
{
    Task<IEnumerable<CardIssuer>> GetAllAsync();
    Task<CardIssuer?> GetByIdAsync(CardIssuerId id);
    Task<CardIssuer?> GetByNameAsync(CardIssuerName name);
    Task AddAsync(CardIssuer cardIssuer);
    Task UpdateAsync(CardIssuer cardIssuer);
    Task DeleteAsync(CardIssuer cardIssuer);
    Task<bool> ExistsAsync(CardIssuerId id);
}

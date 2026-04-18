using GestionAerolineas.src.Modules.CardTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardTypes.Domain.Repositories;

public interface ICardTypeRepository
{
    Task<IEnumerable<CardType>> GetAllAsync();
    Task<CardType?> GetByIdAsync(CardTypeId id);
    Task<CardType?> GetByNameAsync(CardTypeName name);
    Task AddAsync(CardType cardType);
    Task UpdateAsync(CardType cardType);
    Task DeleteAsync(CardType cardType);
    Task<bool> ExistsAsync(CardTypeId id);
}

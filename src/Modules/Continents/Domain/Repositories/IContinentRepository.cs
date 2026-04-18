using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Domain.Repositories;

public interface IContinentRepository
{
    Task<IEnumerable<Continent>> GetAllAsync();
    Task<Continent?> GetByIdAsync(ContinentId id);
    Task<Continent?> GetByNameAsync(ContinentName name);
    Task AddAsync(Continent continent);
    Task UpdateAsync(Continent continent);
    Task DeleteAsync(Continent continent);
    Task<bool> ExistsAsync(ContinentId id);
}


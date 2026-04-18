using GestionAerolineas.src.Modules.Seasons.Domain.Aggregate;
using GestionAerolineas.src.Modules.Seasons.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Seasons.Domain.Repositories;

public interface ISeasonRepository
{
    Task<IEnumerable<Season>> GetAllAsync();
    Task<Season?> GetByIdAsync(SeasonId id);
    Task<Season?> GetByNameAsync(SeasonName name);
    Task AddAsync(Season season);
    Task UpdateAsync(Season season);
    Task DeleteAsync(Season season);
    Task<bool> ExistsAsync(SeasonId id);
}

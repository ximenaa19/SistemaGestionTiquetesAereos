using GestionAerolineas.src.Modules.Regions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Regions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Regions.Domain.Repositories;

public interface IRegionRepository
{
    Task<IEnumerable<Region>> GetAllAsync();
    Task<Region?> GetByIdAsync(RegionId id);
    Task<Region?> GetByNameAsync(RegionName name);
    Task AddAsync(Region region);
    Task UpdateAsync(Region region);
    Task DeleteAsync(Region region);
    Task<bool> ExistsAsync(RegionId id);
    Task<bool> ExistsByNormalizedNameInCountryAsync(string normalizedName, int countryId, int? excludingId = null);
}

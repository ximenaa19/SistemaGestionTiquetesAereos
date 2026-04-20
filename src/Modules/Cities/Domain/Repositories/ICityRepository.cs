using GestionAerolineas.src.Modules.Cities.Domain.Aggregate;
using GestionAerolineas.src.Modules.Cities.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Cities.Domain.Repositories;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetAllAsync();
    Task<City?> GetByIdAsync(CityId id);
    Task<City?> GetByNameAsync(CityName name);
    Task AddAsync(City city);
    Task UpdateAsync(City city);
    Task DeleteAsync(City city);
    Task<bool> ExistsAsync(CityId id);
    Task<bool> ExistsByNormalizedNameInRegionAsync(string normalizedName, int regionId, int? excludingId = null);
}

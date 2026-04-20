using GestionAerolineas.src.Modules.Airports.Domain.Aggregate;
using GestionAerolineas.src.Modules.Airports.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airports.Domain.Repositories;

public interface IAirportRepository
{
    Task<IEnumerable<Airport>> GetAllAsync();
    Task<Airport?> GetByIdAsync(AirportId id);
    Task<Airport?> GetByNameAsync(AirportName name);
    Task AddAsync(Airport airport);
    Task UpdateAsync(Airport airport);
    Task DeleteAsync(Airport airport);
    Task<bool> ExistsAsync(AirportId id);
    Task<bool> ExistsByNormalizedNameInCityAsync(string normalizedName, int cityId, int? excludingId = null);
    Task<bool> ExistsByNormalizedIataCodeAsync(string normalizedIataCode, int? excludingId = null);
    Task<bool> ExistsByNormalizedIcaoCodeAsync(string normalizedIcaoCode, int? excludingId = null);
}

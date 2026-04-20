using GestionAerolineas.src.Modules.Countries.Domain.Aggregate;
using GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Countries.Domain.Repositories;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<Country?> GetByIdAsync(CountryId id);
    Task<Country?> GetByNameAsync(CountryName name);
    Task<Country?> GetByIsoCodeAsync(CountryCodigoIso isoCode);
    Task AddAsync(Country country);
    Task UpdateAsync(Country country);
    Task DeleteAsync(Country country);
    Task<bool> ExistsAsync(CountryId id);
}


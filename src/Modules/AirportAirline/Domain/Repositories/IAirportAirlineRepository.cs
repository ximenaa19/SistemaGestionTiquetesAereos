using GestionAerolineas.src.Modules.AirportAirline.Domain.Aggregate;
using GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AirportAirline.Domain.Repositories;

public interface IAirportAirlineRepository
{
    Task<IEnumerable<AirportAirlineRelation>> GetAllAsync();
    Task<AirportAirlineRelation?> GetByIdAsync(AirportAirlineId id);
    Task<AirportAirlineRelation?> GetByAirportAndAirlineAsync(AirportAirlineAirportId airportId, AirportAirlineAirlineId airlineId);
    Task AddAsync(AirportAirlineRelation relation);
    Task UpdateAsync(AirportAirlineRelation relation);
    Task DeleteAsync(AirportAirlineRelation relation);
    Task<bool> ExistsAsync(AirportAirlineId id);
    Task<bool> ExistsByAirportAndAirlineAsync(int airportId, int airlineId, int? excludingId = null);
}


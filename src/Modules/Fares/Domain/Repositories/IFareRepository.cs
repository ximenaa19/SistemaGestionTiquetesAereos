using GestionAerolineas.src.Modules.Fares.Domain.Aggregate;
using GestionAerolineas.src.Modules.Fares.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Fares.Domain.Repositories;

public interface IFareRepository
{
    Task<IEnumerable<Fare>> GetAllAsync();
    Task<Fare?> GetByIdAsync(FareId id);
    Task<IEnumerable<Fare>> GetByRouteIdAsync(FareRouteId routeId);
    Task<Fare?> GetByKeysAsync(FareRouteId routeId, FareCabinTypeId cabinTypeId, FarePassengerTypeId passengerTypeId, FareSeasonId seasonId);
    Task AddAsync(Fare fare);
    Task UpdateAsync(Fare fare);
    Task DeleteAsync(Fare fare);
    Task<bool> ExistsAsync(FareId id);
    Task<bool> ExistsByKeysAsync(int routeId, int cabinTypeId, int passengerTypeId, int seasonId, int? excludingId = null);
}


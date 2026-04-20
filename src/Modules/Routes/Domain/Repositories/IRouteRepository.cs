using GestionAerolineas.src.Modules.Routes.Domain.Aggregate;
using GestionAerolineas.src.Modules.Routes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Routes.Domain.Repositories;

public interface IRouteRepository
{
    Task<IEnumerable<Route>> GetAllAsync();
    Task<Route?> GetByIdAsync(RouteId id);
    Task<Route?> GetByOriginAndDestinationAsync(RouteAirportId originAirportId, RouteAirportId destinationAirportId);
    Task AddAsync(Route route);
    Task UpdateAsync(Route route);
    Task DeleteAsync(Route route);
    Task<bool> ExistsAsync(RouteId id);
    Task<bool> ExistsByOriginAndDestinationAsync(int originAirportId, int destinationAirportId, int? excludingId = null);
}


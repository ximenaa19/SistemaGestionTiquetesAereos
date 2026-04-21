using GestionAerolineas.src.Modules.RouteStops.Domain.Aggregate;
using GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RouteStops.Domain.Repositories;

public interface IRouteStopRepository
{
    Task<IEnumerable<RouteStop>> GetAllAsync();
    Task<RouteStop?> GetByIdAsync(RouteStopId id);
    Task<IEnumerable<RouteStop>> GetByRouteIdAsync(RouteStopRouteId routeId);
    Task<RouteStop?> GetByRouteAndOrderAsync(RouteStopRouteId routeId, RouteStopOrder order);
    Task AddAsync(RouteStop routeStop);
    Task UpdateAsync(RouteStop routeStop);
    Task DeleteAsync(RouteStop routeStop);
    Task<bool> ExistsAsync(RouteStopId id);
    Task<bool> ExistsByRouteAndOrderAsync(int routeId, int order, int? excludingId = null);
    Task<bool> ExistsByRouteAndStopAirportAsync(int routeId, int stopAirportId, int? excludingId = null);
}


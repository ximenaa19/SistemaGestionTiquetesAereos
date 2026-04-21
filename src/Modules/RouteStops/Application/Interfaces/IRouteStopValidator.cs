using GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RouteStops.Application.Interfaces;

public interface IRouteStopValidator
{
    Task ValidateRouteExistsAsync(RouteStopRouteId routeId);
    Task ValidateStopAirportExistsAsync(RouteStopStopAirportId stopAirportId);
    Task ValidateUniqueOrderInRouteAsync(RouteStopRouteId routeId, RouteStopOrder order, RouteStopId? currentId = null);
    Task ValidateNoDuplicateStopAirportInRouteAsync(RouteStopRouteId routeId, RouteStopStopAirportId stopAirportId, RouteStopId? currentId = null);
    Task ValidateStopAirportNotOriginOrDestinationAsync(RouteStopRouteId routeId, RouteStopStopAirportId stopAirportId);
}


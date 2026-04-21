using GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RouteStops.Domain.Aggregate;

public class RouteStop
{
    public RouteStopId Id { get; private set; }
    public RouteStopRouteId RouteId { get; private set; }
    public RouteStopStopAirportId StopAirportId { get; private set; }
    public RouteStopOrder Order { get; private set; }
    public RouteStopDurationMinutes DurationMinutes { get; private set; }

    private RouteStop(
        RouteStopId id,
        RouteStopRouteId routeId,
        RouteStopStopAirportId stopAirportId,
        RouteStopOrder order,
        RouteStopDurationMinutes durationMinutes)
    {
        Id = id;
        RouteId = routeId;
        StopAirportId = stopAirportId;
        Order = order;
        DurationMinutes = durationMinutes;
    }

    public static RouteStop Create(
        RouteStopId id,
        RouteStopRouteId routeId,
        RouteStopStopAirportId stopAirportId,
        RouteStopOrder order,
        RouteStopDurationMinutes durationMinutes)
    {
        return new RouteStop(id, routeId, stopAirportId, order, durationMinutes);
    }

    public static RouteStop CreateNew(
        RouteStopRouteId routeId,
        RouteStopStopAirportId stopAirportId,
        RouteStopOrder order,
        RouteStopDurationMinutes durationMinutes)
    {
        return new RouteStop(RouteStopId.CreateEmpty(), routeId, stopAirportId, order, durationMinutes);
    }
}


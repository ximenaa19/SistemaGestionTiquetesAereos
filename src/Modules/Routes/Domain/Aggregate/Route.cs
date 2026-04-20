using GestionAerolineas.src.Modules.Routes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Routes.Domain.Aggregate;

public class Route
{
    public RouteId Id { get; private set; }
    public RouteAirportId OriginAirportId { get; private set; }
    public RouteAirportId DestinationAirportId { get; private set; }
    public RouteDistanceKm DistanceKm { get; private set; }
    public RouteEstimatedDurationMinutes EstimatedDurationMin { get; private set; }

    private Route(
        RouteId id,
        RouteAirportId originAirportId,
        RouteAirportId destinationAirportId,
        RouteDistanceKm distanceKm,
        RouteEstimatedDurationMinutes estimatedDurationMin)
    {
        Id = id;
        OriginAirportId = originAirportId;
        DestinationAirportId = destinationAirportId;
        DistanceKm = distanceKm;
        EstimatedDurationMin = estimatedDurationMin;
    }

    public static Route Create(
        RouteId id,
        RouteAirportId originAirportId,
        RouteAirportId destinationAirportId,
        RouteDistanceKm distanceKm,
        RouteEstimatedDurationMinutes estimatedDurationMin)
    {
        return new Route(id, originAirportId, destinationAirportId, distanceKm, estimatedDurationMin);
    }

    public static Route CreateNew(
        RouteAirportId originAirportId,
        RouteAirportId destinationAirportId,
        RouteDistanceKm distanceKm,
        RouteEstimatedDurationMinutes estimatedDurationMin)
    {
        return new Route(RouteId.CreateEmpty(), originAirportId, destinationAirportId, distanceKm, estimatedDurationMin);
    }
}


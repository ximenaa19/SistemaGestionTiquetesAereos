using GestionAerolineas.src.Modules.Routes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Routes.Application.Interfaces;

public interface IRouteValidator
{
    Task ValidateAirportExistsAsync(RouteAirportId airportId);
    Task ValidateUniquePairAsync(RouteAirportId originAirportId, RouteAirportId destinationAirportId, RouteId? currentId = null);
    Task ValidateDifferentAirportsAsync(RouteAirportId originAirportId, RouteAirportId destinationAirportId);
}


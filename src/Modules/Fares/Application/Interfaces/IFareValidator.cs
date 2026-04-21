using GestionAerolineas.src.Modules.Fares.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Fares.Application.Interfaces;

public interface IFareValidator
{
    Task ValidateRouteExistsAsync(FareRouteId routeId);
    Task ValidateCabinTypeExistsAsync(FareCabinTypeId cabinTypeId);
    Task ValidatePassengerTypeExistsAsync(FarePassengerTypeId passengerTypeId);
    Task ValidateSeasonExistsAsync(FareSeasonId seasonId);
    Task ValidateUniqueKeysAsync(
        FareRouteId routeId,
        FareCabinTypeId cabinTypeId,
        FarePassengerTypeId passengerTypeId,
        FareSeasonId seasonId,
        FareId? currentId = null);

    void ValidateValidFromBeforeValidUntil(FareValidFromDate validFrom, FareValidUntilDate validUntil);
}


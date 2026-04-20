using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStatusTransitions.Application.Interfaces;

public interface IFlightStatusTransitionValidator
{
    Task ValidatePairAsync(
        FlightStateOriginId originStateId,
        FlightStateDestinationId destinationStateId,
        FlightStatusTransitionId? currentId = null
    );
}


using GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightSeats.Application.Interfaces;

public interface IFlightSeatValidator
{
    Task ValidateFlightExistsAsync(FlightSeatFlightId flightId);
    Task ValidateCabinTypeExistsAsync(FlightSeatCabinTypeId cabinTypeId);
    Task ValidateLocationTypeExistsAsync(FlightSeatLocationTypeId locationTypeId);
    Task ValidateUniqueSeatCodeInFlightAsync(FlightSeatFlightId flightId, FlightSeatCode code, FlightSeatId? currentId = null);
    Task ValidateSeatCountWithinFlightCapacityAsync(FlightSeatFlightId flightId, FlightSeatId? currentId = null);
}


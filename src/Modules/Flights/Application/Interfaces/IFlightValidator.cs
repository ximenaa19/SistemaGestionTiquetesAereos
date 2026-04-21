using GestionAerolineas.src.Modules.Flights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Flights.Application.Interfaces;

public interface IFlightValidator
{
    Task ValidateAirlineExistsAsync(FlightAirlineId airlineId);
    Task ValidateRouteExistsAsync(FlightRouteId routeId);
    Task ValidateAircraftExistsAsync(FlightAircraftId aircraftId);
    Task ValidateStateExistsAsync(FlightStateId stateId);
    Task ValidateAircraftBelongsToAirlineAsync(FlightAircraftId aircraftId, FlightAirlineId airlineId);
    Task ValidateUniqueCodeAsync(FlightCode code, FlightId? currentId = null);
    void ValidateDateConsistency(FlightDepartureDateTime departure, FlightEstimatedArrivalDateTime estimatedArrival);
    void ValidateCapacityConsistency(FlightTotalCapacity totalCapacity, FlightAvailableSeats availableSeats);
    void ValidateRescheduledAtConsistency(FlightRescheduledAt rescheduledAt, FlightDepartureDateTime departure);
    Task ValidateAircraftNoOverlapAsync(FlightAircraftId aircraftId, FlightDepartureDateTime departure, FlightEstimatedArrivalDateTime estimatedArrival, FlightId? currentId = null);
}


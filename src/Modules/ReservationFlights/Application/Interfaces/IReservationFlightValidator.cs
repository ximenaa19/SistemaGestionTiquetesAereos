using GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationFlights.Application.Interfaces;

public interface IReservationFlightValidator
{
    Task ValidateReservationExistsAsync(ReservationFlightReservationId reservationId);
    Task ValidateFlightExistsAsync(ReservationFlightFlightId flightId);
    Task ValidateUniquePairAsync(ReservationFlightReservationId reservationId, ReservationFlightFlightId flightId, ReservationFlightId? currentId = null);
    Task ValidateFlightNotInFinalStateAsync(ReservationFlightFlightId flightId);
    Task ValidateReservationAllowsChangesAsync(ReservationFlightReservationId reservationId);
    Task ValidateNoPassengersAsync(ReservationFlightId reservationFlightId);
}

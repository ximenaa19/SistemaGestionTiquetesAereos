using GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationPassengers.Application.Interfaces;

public interface IReservationPassengerValidator
{
    Task ValidateReservationFlightExistsAsync(ReservationPassengerReservationFlightId reservationFlightId);
    Task ValidatePassengerExistsAsync(ReservationPassengerPassengerId passengerId);
    Task ValidateUniquePairAsync(ReservationPassengerReservationFlightId reservationFlightId, ReservationPassengerPassengerId passengerId, ReservationPassengerId? currentId = null);
    Task ValidateReservationAllowsChangesAsync(ReservationPassengerReservationFlightId reservationFlightId);
    Task ValidateFlightHasAvailabilityAsync(ReservationPassengerReservationFlightId reservationFlightId, int seatsToConsume);
}


using GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationPassengers.Domain.Aggregate;

public class ReservationPassenger
{
    public ReservationPassengerId Id { get; private set; }
    public ReservationPassengerReservationFlightId ReservationFlightId { get; private set; }
    public ReservationPassengerPassengerId PassengerId { get; private set; }

    private ReservationPassenger(
        ReservationPassengerId id,
        ReservationPassengerReservationFlightId reservationFlightId,
        ReservationPassengerPassengerId passengerId)
    {
        Id = id;
        ReservationFlightId = reservationFlightId;
        PassengerId = passengerId;
    }

    public static ReservationPassenger Create(
        ReservationPassengerId id,
        ReservationPassengerReservationFlightId reservationFlightId,
        ReservationPassengerPassengerId passengerId)
    {
        return new ReservationPassenger(id, reservationFlightId, passengerId);
    }

    public static ReservationPassenger CreateNew(
        ReservationPassengerReservationFlightId reservationFlightId,
        ReservationPassengerPassengerId passengerId)
    {
        return new ReservationPassenger(ReservationPassengerId.CreateEmpty(), reservationFlightId, passengerId);
    }
}


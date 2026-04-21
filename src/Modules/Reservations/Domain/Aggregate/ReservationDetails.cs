using GestionAerolineas.src.Modules.ReservationFlights.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Aggregate;

namespace GestionAerolineas.src.Modules.Reservations.Domain.Aggregate;

public sealed class ReservationDetails
{
    public Reservation Reservation { get; }
    public IReadOnlyList<ReservationFlight> ReservationFlights { get; }
    public IReadOnlyList<ReservationPassenger> ReservationPassengers { get; }

    private ReservationDetails(
        Reservation reservation,
        IReadOnlyList<ReservationFlight> reservationFlights,
        IReadOnlyList<ReservationPassenger> reservationPassengers)
    {
        Reservation = reservation;
        ReservationFlights = reservationFlights;
        ReservationPassengers = reservationPassengers;
    }

    public static ReservationDetails Create(
        Reservation reservation,
        IEnumerable<ReservationFlight> reservationFlights,
        IEnumerable<ReservationPassenger> reservationPassengers)
    {
        return new ReservationDetails(
            reservation,
            reservationFlights.ToList(),
            reservationPassengers.ToList());
    }
}


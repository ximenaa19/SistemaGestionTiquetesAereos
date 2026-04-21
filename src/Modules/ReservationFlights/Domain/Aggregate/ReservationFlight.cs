using GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationFlights.Domain.Aggregate;

public class ReservationFlight
{
    public ReservationFlightId Id { get; private set; }
    public ReservationFlightReservationId ReservationId { get; private set; }
    public ReservationFlightFlightId FlightId { get; private set; }
    public ReservationFlightPartialAmount PartialAmount { get; private set; }

    private ReservationFlight(
        ReservationFlightId id,
        ReservationFlightReservationId reservationId,
        ReservationFlightFlightId flightId,
        ReservationFlightPartialAmount partialAmount)
    {
        Id = id;
        ReservationId = reservationId;
        FlightId = flightId;
        PartialAmount = partialAmount;
    }

    public static ReservationFlight Create(
        ReservationFlightId id,
        ReservationFlightReservationId reservationId,
        ReservationFlightFlightId flightId,
        ReservationFlightPartialAmount partialAmount)
    {
        return new ReservationFlight(id, reservationId, flightId, partialAmount);
    }

    public static ReservationFlight CreateNew(
        ReservationFlightReservationId reservationId,
        ReservationFlightFlightId flightId,
        ReservationFlightPartialAmount partialAmount)
    {
        return new ReservationFlight(ReservationFlightId.CreateEmpty(), reservationId, flightId, partialAmount);
    }
}


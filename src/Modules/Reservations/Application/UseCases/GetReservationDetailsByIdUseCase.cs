using GestionAerolineas.src.Modules.ReservationFlights.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject;
using GestionAerolineas.src.Modules.Reservations.Domain.Aggregate;
using GestionAerolineas.src.Modules.Reservations.Domain.Repositories;
using GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Reservations.Application.UseCases;

public class GetReservationDetailsByIdUseCase
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IReservationFlightRepository _reservationFlightRepository;
    private readonly IReservationPassengerRepository _reservationPassengerRepository;

    public GetReservationDetailsByIdUseCase(
        IReservationRepository reservationRepository,
        IReservationFlightRepository reservationFlightRepository,
        IReservationPassengerRepository reservationPassengerRepository)
    {
        _reservationRepository = reservationRepository;
        _reservationFlightRepository = reservationFlightRepository;
        _reservationPassengerRepository = reservationPassengerRepository;
    }

    public async Task<ReservationDetails?> ExecuteAsync(int reservationId)
    {
        var reservation = await _reservationRepository.GetByIdAsync(ReservationId.Create(reservationId));
        if (reservation is null)
            return null;

        var flights = (await _reservationFlightRepository.GetByReservationIdAsync(
            ReservationFlightReservationId.Create(reservationId))).ToList();

        var passengers = new List<ReservationPassengers.Domain.Aggregate.ReservationPassenger>();
        foreach (var rf in flights)
        {
            var list = await _reservationPassengerRepository.GetByReservationFlightIdAsync(
                ReservationPassengerReservationFlightId.Create(rf.Id.Value));
            passengers.AddRange(list);
        }

        return ReservationDetails.Create(reservation, flights, passengers);
    }
}


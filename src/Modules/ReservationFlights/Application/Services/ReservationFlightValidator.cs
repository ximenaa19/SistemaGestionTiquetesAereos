using GestionAerolineas.src.Modules.FlightStates.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Flights.Domain.ValueObject;
using GestionAerolineas.src.Modules.Flights.Infrastructure.Repository;
using GestionAerolineas.src.Modules.ReservationFlights.Application.Interfaces;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject;
using GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;
using GestionAerolineas.src.Modules.Reservations.Infrastructure.Repository;
using FlightStatesFlightStateId = GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject.FlightStateId;

namespace GestionAerolineas.src.Modules.ReservationFlights.Application.Services;

public class ReservationFlightValidator : IReservationFlightValidator
{
    private readonly IReservationFlightRepository _repository;
    private readonly ReservationRepository _reservationRepository;
    private readonly FlightRepository _flightRepository;
    private readonly FlightStateRepository _flightStateRepository;

    public ReservationFlightValidator(
        IReservationFlightRepository repository,
        ReservationRepository reservationRepository,
        FlightRepository flightRepository,
        FlightStateRepository flightStateRepository)
    {
        _repository = repository;
        _reservationRepository = reservationRepository;
        _flightRepository = flightRepository;
        _flightStateRepository = flightStateRepository;
    }

    public async Task ValidateReservationExistsAsync(ReservationFlightReservationId reservationId)
    {
        var exists = await _reservationRepository.ExistsAsync(ReservationId.Create(reservationId.Value));
        if (!exists)
            throw new Exception("La reserva no existe");
    }

    public async Task ValidateFlightExistsAsync(ReservationFlightFlightId flightId)
    {
        var exists = await _flightRepository.ExistsAsync(FlightId.Create(flightId.Value));
        if (!exists)
            throw new Exception("El vuelo no existe");
    }

    public async Task ValidateUniquePairAsync(ReservationFlightReservationId reservationId, ReservationFlightFlightId flightId, ReservationFlightId? currentId = null)
    {
        var exists = await _repository.ExistsByReservationAndFlightAsync(reservationId.Value, flightId.Value, currentId?.Value);
        if (exists)
            throw new Exception("Ese vuelo ya esta agregado a la reserva");
    }

    public async Task ValidateFlightNotInFinalStateAsync(ReservationFlightFlightId flightId)
    {
        var flight = await _flightRepository.GetByIdAsync(FlightId.Create(flightId.Value));
        if (flight is null)
            throw new Exception("El vuelo no existe");

        var state = await _flightStateRepository.GetByIdAsync(FlightStatesFlightStateId.Create(flight.StateId.Value));
        var name = (state?.Name.Value ?? string.Empty).Trim().ToUpperInvariant();

        if (name == "CANCELADO" || name == "COMPLETADO")
            throw new Exception($"No se puede agregar un vuelo en estado '{state!.Name.Value}' a una reserva");
    }
}


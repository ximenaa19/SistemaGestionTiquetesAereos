using GestionAerolineas.src.Modules.ReservationFlights.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationFlights.Domain.Repositories;

public interface IReservationFlightRepository
{
    Task<IEnumerable<ReservationFlight>> GetAllAsync();
    Task<ReservationFlight?> GetByIdAsync(ReservationFlightId id);
    Task<IEnumerable<ReservationFlight>> GetByReservationIdAsync(ReservationFlightReservationId reservationId);
    Task<IEnumerable<ReservationFlight>> GetByFlightIdAsync(ReservationFlightFlightId flightId);
    Task<ReservationFlight?> GetByReservationAndFlightAsync(ReservationFlightReservationId reservationId, ReservationFlightFlightId flightId);
    Task AddAsync(ReservationFlight reservationFlight);
    Task UpdateAsync(ReservationFlight reservationFlight);
    Task DeleteAsync(ReservationFlight reservationFlight);
    Task<bool> ExistsAsync(ReservationFlightId id);
    Task<bool> ExistsByReservationAndFlightAsync(int reservationId, int flightId, int? excludingId = null);
    Task<decimal> SumPartialAmountByReservationIdAsync(int reservationId);
}


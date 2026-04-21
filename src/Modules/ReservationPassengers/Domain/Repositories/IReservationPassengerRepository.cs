using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationPassengers.Domain.Repositories;

public interface IReservationPassengerRepository
{
    Task<IEnumerable<ReservationPassenger>> GetAllAsync();
    Task<ReservationPassenger?> GetByIdAsync(ReservationPassengerId id);
    Task<IEnumerable<ReservationPassenger>> GetByReservationFlightIdAsync(ReservationPassengerReservationFlightId reservationFlightId);
    Task<IEnumerable<ReservationPassenger>> GetByPassengerIdAsync(ReservationPassengerPassengerId passengerId);
    Task<ReservationPassenger?> GetByReservationFlightAndPassengerAsync(ReservationPassengerReservationFlightId reservationFlightId, ReservationPassengerPassengerId passengerId);
    Task AddAsync(ReservationPassenger reservationPassenger);
    Task UpdateAsync(ReservationPassenger reservationPassenger);
    Task DeleteAsync(ReservationPassenger reservationPassenger);
    Task<bool> ExistsAsync(ReservationPassengerId id);
    Task<bool> ExistsByReservationFlightAndPassengerAsync(int reservationFlightId, int passengerId, int? excludingId = null);
}


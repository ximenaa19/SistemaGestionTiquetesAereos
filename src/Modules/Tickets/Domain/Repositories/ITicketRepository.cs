using GestionAerolineas.src.Modules.Tickets.Domain.Aggregate;
using GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Tickets.Domain.Repositories;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(TicketId id);
    Task<Ticket?> GetByCodeAsync(TicketCode code);
    Task<Ticket?> GetByReservationPassengerIdAsync(TicketReservationPassengerId reservationPassengerId);
    Task<IEnumerable<Ticket>> GetByStatusIdAsync(TicketStatusId statusId);
    Task<IEnumerable<Ticket>> GetByPassengerIdAsync(int passengerId);
    Task<IEnumerable<Ticket>> GetByReservationCodeAsync(string reservationCode);
    Task AddAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task DeleteAsync(Ticket ticket);
    Task<bool> ExistsAsync(TicketId id);
    Task<bool> ExistsByReservationPassengerIdAsync(int reservationPassengerId, int? excludingTicketId = null);
    Task<bool> ExistsByNormalizedCodeAsync(string normalizedCode, int? excludingTicketId = null);
}


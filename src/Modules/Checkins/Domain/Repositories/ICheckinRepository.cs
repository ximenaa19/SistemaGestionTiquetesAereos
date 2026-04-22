using GestionAerolineas.src.Modules.Checkins.Domain.Aggregate;
using GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Checkins.Domain.Repositories;

public interface ICheckinRepository
{
    Task<IEnumerable<Checkin>> GetAllAsync();
    Task<Checkin?> GetByIdAsync(CheckinId id);
    Task<Checkin?> GetByTicketIdAsync(CheckinTicketId ticketId);
    Task<IEnumerable<Checkin>> GetByPassengerIdAsync(int passengerId);
    Task<IEnumerable<Checkin>> GetByFlightIdAsync(int flightId);
    Task<IEnumerable<Checkin>> GetByStatusIdAsync(CheckinStatusId statusId);
    Task<IEnumerable<Checkin>> GetByCheckedAtRangeAsync(DateTime fromInclusive, DateTime toInclusive);
    Task<int?> GetTicketFlightIdAsync(int ticketId);

    Task AddAsync(Checkin checkin);
    Task UpdateAsync(Checkin checkin);
    Task DeleteAsync(Checkin checkin);

    Task<bool> ExistsAsync(CheckinId id);
    Task<bool> ExistsByTicketIdAsync(int ticketId, int? excludingId = null);
    Task<bool> ExistsByFlightSeatIdAsync(int flightSeatId, int? excludingId = null);
    Task<bool> ExistsByNormalizedBoardingPassAsync(string normalizedBoardingPass, int? excludingId = null);
}

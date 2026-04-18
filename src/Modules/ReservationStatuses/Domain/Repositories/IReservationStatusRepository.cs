using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatuses.Domain.Repositories;

public interface IReservationStatusRepository
{
    Task<IEnumerable<ReservationStatus>> GetAllAsync();
    Task<ReservationStatus?> GetByIdAsync(ReservationStatusId id);
    Task<ReservationStatus?> GetByNameAsync(ReservationStatusName name);
    Task AddAsync(ReservationStatus reservationStatus);
    Task UpdateAsync(ReservationStatus reservationStatus);
    Task DeleteAsync(ReservationStatus reservationStatus);
    Task<bool> ExistsAsync(ReservationStatusId id);
}


using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Repositories;

public interface ISeatLocationTypeRepository
{
    Task<IEnumerable<SeatLocationType>> GetAllAsync();
    Task<SeatLocationType?> GetByIdAsync(SeatLocationTypeId id);
    Task<SeatLocationType?> GetByNameAsync(SeatLocationTypeName name);
    Task<int> CountAsync();
    Task AddAsync(SeatLocationType seatLocationType);
    Task UpdateAsync(SeatLocationType seatLocationType);
    Task DeleteAsync(SeatLocationType seatLocationType);
    Task<bool> ExistsAsync(SeatLocationTypeId id);
}


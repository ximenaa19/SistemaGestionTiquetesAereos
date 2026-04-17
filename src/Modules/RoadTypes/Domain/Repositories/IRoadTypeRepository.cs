using System;
using GestionAerolineas.src.Modules.RoadTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RoadTypes.Domain.Repositories;

public interface IRoadTypeRepository
{
    Task<IEnumerable<RoadType>> GetAllAsync();
    Task<RoadType?> GetByIdAsync(RoadTypeId id);
    Task<RoadType?> GetByNameAsync(RoadTypeName name);
    Task AddAsync(RoadType roadType);
    Task UpdateAsync(RoadType roadType);
    Task DeleteAsync(RoadType roadType);
    Task<bool> ExistsAsync(RoadTypeId id);

}
     
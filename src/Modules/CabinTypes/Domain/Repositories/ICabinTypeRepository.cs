using System;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinTypes.Domain.Repository;

public interface ICabinTypeRepository
{
    Task<IEnumerable<CabinType>> GetAllAsync();
    Task<CabinType?> GetByIdAsync(CabinTypesId id);
    Task<CabinType?> GetByNameAsync(CabinTypesName name);
    Task AddAsync(CabinType cabinType);
    Task UpdateAsync(CabinType cabinType);
    Task DeleteAsync(CabinType cabinType);
    Task<bool> ExistsAsync(CabinTypesId id);

}

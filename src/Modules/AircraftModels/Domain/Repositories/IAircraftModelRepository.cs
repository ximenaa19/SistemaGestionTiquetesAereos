using GestionAerolineas.src.Modules.AircraftModels.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftModels.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftModels.Domain.Repositories;

public interface IAircraftModelRepository
{
    Task<IEnumerable<AircraftModel>> GetAllAsync();
    Task<AircraftModel?> GetByIdAsync(AircraftModelId id);
    Task<AircraftModel?> GetByNameAsync(AircraftModelName modelName);
    Task AddAsync(AircraftModel aircraftModel);
    Task UpdateAsync(AircraftModel aircraftModel);
    Task DeleteAsync(AircraftModel aircraftModel);
    Task<bool> ExistsAsync(AircraftModelId id);
}


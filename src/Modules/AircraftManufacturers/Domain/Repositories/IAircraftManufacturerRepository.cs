using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Repositories;

public interface IAircraftManufacturerRepository
{
    Task<IEnumerable<AircraftManufacturer>> GetAllAsync();
    Task<AircraftManufacturer?> GetByIdAsync(AircraftManufacturerId id);
    Task<AircraftManufacturer?> GetByNameAsync(AircraftManufacturerName name);
    Task AddAsync(AircraftManufacturer manufacturer);
    Task UpdateAsync(AircraftManufacturer manufacturer);
    Task DeleteAsync(AircraftManufacturer manufacturer);
    Task<bool> ExistsAsync(AircraftManufacturerId id);
}


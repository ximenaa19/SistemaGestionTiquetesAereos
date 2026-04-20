using GestionAerolineas.src.Modules.Aircraft.Domain.Aggregate;
using GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Aircraft.Domain.Repositories;

public interface IAircraftRepository
{
    Task<IEnumerable<AircraftAggregate>> GetAllAsync();
    Task<AircraftAggregate?> GetByIdAsync(AircraftId id);
    Task<AircraftAggregate?> GetByRegistrationAsync(AircraftRegistration registration);
    Task AddAsync(AircraftAggregate aircraft);
    Task UpdateAsync(AircraftAggregate aircraft);
    Task DeleteAsync(AircraftAggregate aircraft);
    Task<bool> ExistsAsync(AircraftId id);
    Task<bool> ExistsByNormalizedRegistrationAsync(string normalizedRegistration, int? excludingId = null);
}


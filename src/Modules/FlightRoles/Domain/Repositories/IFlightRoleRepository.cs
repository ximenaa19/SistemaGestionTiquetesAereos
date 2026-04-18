using GestionAerolineas.src.Modules.FlightRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightRoles.Domain.Repositories;

public interface IFlightRoleRepository
{
    Task<IEnumerable<FlightRole>> GetAllAsync();
    Task<FlightRole?> GetByIdAsync(FlightRoleId id);
    Task<FlightRole?> GetByNameAsync(FlightRoleName name);
    Task AddAsync(FlightRole flightRole);
    Task UpdateAsync(FlightRole flightRole);
    Task DeleteAsync(FlightRole flightRole);
    Task<bool> ExistsAsync(FlightRoleId id);
}


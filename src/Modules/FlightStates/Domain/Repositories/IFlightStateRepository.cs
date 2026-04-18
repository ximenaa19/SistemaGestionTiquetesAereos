using GestionAerolineas.src.Modules.FlightStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStates.Domain.Repositories;

public interface IFlightStateRepository
{
    Task<IEnumerable<FlightState>> GetAllAsync();
    Task<FlightState?> GetByIdAsync(FlightStateId id);
    Task<FlightState?> GetByNameAsync(FlightStateName name);
    Task AddAsync(FlightState flightState);
    Task UpdateAsync(FlightState flightState);
    Task DeleteAsync(FlightState flightState);
    Task<bool> ExistsAsync(FlightStateId id);
}

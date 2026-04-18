using GestionAerolineas.src.Modules.PassengerTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PassengerTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PassengerTypes.Domain.Repositories;

public interface IPassengerTypeRepository
{
    Task<IEnumerable<PassengerType>> GetAllAsync();
    Task<PassengerType?> GetByIdAsync(PassengerTypeId id);
    Task<PassengerType?> GetByNameAsync(PassengerTypeName name);
    Task AddAsync(PassengerType passengerType);
    Task UpdateAsync(PassengerType passengerType);
    Task DeleteAsync(PassengerType passengerType);
    Task<bool> ExistsAsync(PassengerTypeId id);
}


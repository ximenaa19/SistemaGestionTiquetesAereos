using GestionAerolineas.src.Modules.Passengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.Passengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Passengers.Domain.Repositories;

public interface IPassengerRepository
{
    Task<IEnumerable<Passenger>> GetAllAsync();
    Task<Passenger?> GetByIdAsync(PassengerId id);
    Task<Passenger?> GetByPersonIdAsync(PassengerPersonId personId);
    Task<Passenger?> GetByPersonNameAsync(PassengerPersonName personName);
    Task AddAsync(Passenger passenger);
    Task UpdateAsync(Passenger passenger);
    Task DeleteAsync(Passenger passenger);
    Task<bool> ExistsAsync(PassengerId id);
    Task<bool> ExistsByPersonIdAsync(PassengerPersonId personId, PassengerId? excludingId = null);
}

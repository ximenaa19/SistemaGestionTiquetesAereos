using GestionAerolineas.src.Modules.Customers.Domain.Aggregate;
using GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Customers.Domain.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(CustomerId id);
    Task<Customer?> GetByPersonIdAsync(CustomerPersonId personId);
    Task<Customer?> GetByPersonNameAsync(CustomerPersonName personName);
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(Customer customer);
    Task<bool> ExistsAsync(CustomerId id);
    Task<bool> ExistsByPersonIdAsync(CustomerPersonId personId, CustomerId? excludingId = null);
}

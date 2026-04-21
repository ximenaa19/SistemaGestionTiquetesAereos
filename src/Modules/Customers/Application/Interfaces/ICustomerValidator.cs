using GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Customers.Application.Interfaces;

public interface ICustomerValidator
{
    Task ValidatePersonExistsAsync(CustomerPersonId personId);
    Task ValidatePersonIsUniqueAsync(CustomerPersonId personId, CustomerId? currentId = null);
}

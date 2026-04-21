using GestionAerolineas.src.Modules.Customers.Domain.Aggregate;
using GestionAerolineas.src.Modules.Customers.Domain.Repositories;
using GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Customers.Application.UseCases;

public class GetCustomerByPersonIdUseCase
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByPersonIdUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public Task<Customer?> ExecuteAsync(int personId)
    {
        return _repository.GetByPersonIdAsync(CustomerPersonId.Create(personId));
    }
}

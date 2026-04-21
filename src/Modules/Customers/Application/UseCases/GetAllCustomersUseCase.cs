using GestionAerolineas.src.Modules.Customers.Domain.Aggregate;
using GestionAerolineas.src.Modules.Customers.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Customers.Application.UseCases;

public class GetAllCustomersUseCase
{
    private readonly ICustomerRepository _repository;

    public GetAllCustomersUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Customer>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

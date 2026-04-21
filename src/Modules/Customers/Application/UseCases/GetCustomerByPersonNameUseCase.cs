using GestionAerolineas.src.Modules.Customers.Domain.Aggregate;
using GestionAerolineas.src.Modules.Customers.Domain.Repositories;
using GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Customers.Application.UseCases;

public class GetCustomerByPersonNameUseCase
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByPersonNameUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public Task<Customer?> ExecuteAsync(string personName)
    {
        return _repository.GetByPersonNameAsync(CustomerPersonName.Create(personName));
    }
}

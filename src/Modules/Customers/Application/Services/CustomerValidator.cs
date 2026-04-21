using GestionAerolineas.src.Modules.Customers.Application.Interfaces;
using GestionAerolineas.src.Modules.Customers.Domain.Repositories;
using GestionAerolineas.src.Modules.Customers.Domain.ValueObject;
using GestionAerolineas.src.Modules.People.Domain.ValueObject;
using GestionAerolineas.src.Modules.People.Infrastructure.Repository;

namespace GestionAerolineas.src.Modules.Customers.Application.Services;

public class CustomerValidator : ICustomerValidator
{
    private readonly ICustomerRepository _repository;
    private readonly PersonRepository _personRepository;

    public CustomerValidator(ICustomerRepository repository, PersonRepository personRepository)
    {
        _repository = repository;
        _personRepository = personRepository;
    }

    public async Task ValidatePersonExistsAsync(CustomerPersonId personId)
    {
        var exists = await _personRepository.ExistsAsync(PersonId.Create(personId.Value));
        if (!exists)
            throw new Exception("La persona no existe");
    }

    public async Task ValidatePersonIsUniqueAsync(CustomerPersonId personId, CustomerId? currentId = null)
    {
        var exists = await _repository.ExistsByPersonIdAsync(personId, currentId);
        if (exists)
            throw new Exception("Ya existe un customer para esta persona");
    }
}

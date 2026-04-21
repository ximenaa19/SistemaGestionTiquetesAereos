using GestionAerolineas.src.Modules.Customers.Application.Interfaces;
using GestionAerolineas.src.Modules.Customers.Application.Services;
using GestionAerolineas.src.Modules.Customers.Application.UseCases;
using GestionAerolineas.src.Modules.Customers.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Customers.UI;
using GestionAerolineas.src.Modules.People.Application.UseCases;
using GestionAerolineas.src.Modules.People.Infrastructure.Repository;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Customers;

public static class CustomerModule
{
    public static CustomerMenu Build(AppDbContext context)
    {
        var repository = new CustomerRepository(context);

        var personRepository = new PersonRepository(context);
        ICustomerValidator validator = new CustomerValidator(repository, personRepository);

        var create = new CreateCustomerUseCase(repository, validator);
        var getAll = new GetAllCustomersUseCase(repository);
        var getById = new GetCustomerByIdUseCase(repository);
        var getByPersonId = new GetCustomerByPersonIdUseCase(repository);
        var getByPersonName = new GetCustomerByPersonNameUseCase(repository);
        var update = new UpdateCustomerUseCase(repository, validator);
        var delete = new DeleteCustomerUseCase(repository);

        var getAllPeople = new GetAllPeopleUseCase(personRepository);

        return new CustomerMenu(create, getAll, getById, getByPersonId, getByPersonName, update, delete, getAllPeople);
    }
}

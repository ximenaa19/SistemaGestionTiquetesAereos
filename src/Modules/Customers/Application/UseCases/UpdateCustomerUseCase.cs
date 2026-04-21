using GestionAerolineas.src.Modules.Customers.Application.Interfaces;
using GestionAerolineas.src.Modules.Customers.Domain.Aggregate;
using GestionAerolineas.src.Modules.Customers.Domain.Repositories;
using GestionAerolineas.src.Modules.Customers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Customers.Application.UseCases;

public class UpdateCustomerUseCase
{
    private readonly ICustomerRepository _repository;
    private readonly ICustomerValidator _validator;

    public UpdateCustomerUseCase(ICustomerRepository repository, ICustomerValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, int personId)
    {
        var idVO = CustomerId.Create(id);
        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
            throw new Exception("El customer no existe");

        var personVO = CustomerPersonId.Create(personId);

        await _validator.ValidatePersonExistsAsync(personVO);
        await _validator.ValidatePersonIsUniqueAsync(personVO, idVO);

        var entity = Customer.Create(idVO, personVO, existing.CreatedAt);
        await _repository.UpdateAsync(entity);
    }
}

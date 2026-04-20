using GestionAerolineas.src.Modules.Addresses.Domain.Repositories;
using GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Addresses.Application.UseCases;

public class DeleteAddressUseCase
{
    private readonly IAddressRepository _repository;

    public DeleteAddressUseCase(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(AddressId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


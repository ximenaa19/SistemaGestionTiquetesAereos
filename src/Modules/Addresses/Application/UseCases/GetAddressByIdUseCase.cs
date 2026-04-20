using GestionAerolineas.src.Modules.Addresses.Domain.Aggregate;
using GestionAerolineas.src.Modules.Addresses.Domain.Repositories;
using GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Addresses.Application.UseCases;

public class GetAddressByIdUseCase
{
    private readonly IAddressRepository _repository;

    public GetAddressByIdUseCase(IAddressRepository repository)
    {
        _repository = repository;
    }

    public Task<Address?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(AddressId.Create(id));
    }
}


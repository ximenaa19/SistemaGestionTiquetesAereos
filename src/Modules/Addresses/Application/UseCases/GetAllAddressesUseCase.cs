using GestionAerolineas.src.Modules.Addresses.Domain.Aggregate;
using GestionAerolineas.src.Modules.Addresses.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Addresses.Application.UseCases;

public class GetAllAddressesUseCase
{
    private readonly IAddressRepository _repository;

    public GetAllAddressesUseCase(IAddressRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Address>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


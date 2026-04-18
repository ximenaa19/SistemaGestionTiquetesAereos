using GestionAerolineas.src.Modules.PassengerTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PassengerTypes.Domain.Repositories;

namespace GestionAerolineas.src.Modules.PassengerTypes.Application.UseCases;

public class GetAllPassengerTypesUseCase
{
    private readonly IPassengerTypeRepository _repository;

    public GetAllPassengerTypesUseCase(IPassengerTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PassengerType>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}


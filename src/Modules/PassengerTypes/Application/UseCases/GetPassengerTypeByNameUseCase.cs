using GestionAerolineas.src.Modules.PassengerTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PassengerTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.PassengerTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PassengerTypes.Application.UseCases;

public class GetPassengerTypeByNameUseCase
{
    private readonly IPassengerTypeRepository _repository;

    public GetPassengerTypeByNameUseCase(IPassengerTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PassengerType?> ExecuteAsync(string name)
    {
        var nameVO = PassengerTypeName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}


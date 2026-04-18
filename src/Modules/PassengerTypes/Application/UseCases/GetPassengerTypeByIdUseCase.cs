using GestionAerolineas.src.Modules.PassengerTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PassengerTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.PassengerTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PassengerTypes.Application.UseCases;

public class GetPassengerTypeByIdUseCase
{
    private readonly IPassengerTypeRepository _repository;

    public GetPassengerTypeByIdUseCase(IPassengerTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PassengerType?> ExecuteAsync(int id)
    {
        var idVO = PassengerTypeId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}


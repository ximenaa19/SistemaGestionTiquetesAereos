using GestionAerolineas.src.Modules.PassengerTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.PassengerTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PassengerTypes.Application.UseCases;

public class DeletePassengerTypeUseCase
{
    private readonly IPassengerTypeRepository _repository;

    public DeletePassengerTypeUseCase(IPassengerTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var passengerTypeId = PassengerTypeId.Create(id);
        var passengerType = await _repository.GetByIdAsync(passengerTypeId);

        if (passengerType is null)
            throw new KeyNotFoundException($"PassengerType con id '{passengerTypeId.Value}' no existe.");

        await _repository.DeleteAsync(passengerType);
    }
}


using GestionAerolineas.src.Modules.PassengerTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.PassengerTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.PassengerTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PassengerTypes.Application.Services;

public class PassengerTypeValidator : IPassengerTypeValidator
{
    private readonly IPassengerTypeRepository _repository;

    public PassengerTypeValidator(IPassengerTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(PassengerTypeName name, PassengerTypeId? currentId = null)
    {
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe un tipo de pasajero con ese nombre");
    }
}

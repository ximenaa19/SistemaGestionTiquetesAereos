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
        var normalizedCandidate = PassengerTypeName.Normalize(name.Value);
        var all = await _repository.GetAllAsync();

        foreach (var item in all)
        {
            if (currentId != null && item.Id.Value == currentId.Value)
                continue;

            if (PassengerTypeName.Normalize(item.Name.Value) == normalizedCandidate)
                throw new Exception("Ya existe un tipo de pasajero con ese nombre");
        }
    }
}


using GestionAerolineas.src.Modules.PassengerTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PassengerTypes.Application.Interfaces;

public interface IPassengerTypeValidator
{
    Task ValidateNameAsync(PassengerTypeName name, PassengerTypeId? currentId = null);
}


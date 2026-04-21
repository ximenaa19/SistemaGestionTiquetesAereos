using GestionAerolineas.src.Modules.Passengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Passengers.Application.Interfaces;

public interface IPassengerValidator
{
    Task ValidatePersonExistsAsync(PassengerPersonId personId);
    Task ValidatePassengerTypeExistsAsync(PassengerTypeId passengerTypeId);
    Task ValidatePersonIsUniqueAsync(PassengerPersonId personId, PassengerId? currentId = null);
}

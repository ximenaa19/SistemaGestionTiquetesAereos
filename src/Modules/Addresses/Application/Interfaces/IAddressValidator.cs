using GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Addresses.Application.Interfaces;

public interface IAddressValidator
{
    Task ValidateRoadTypeExistsAsync(AddressRoadTypeId roadTypeId);
    Task ValidateCityExistsAsync(AddressCityId cityId);
}


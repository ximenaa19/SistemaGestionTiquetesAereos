using GestionAerolineas.src.Modules.Addresses.Application.Interfaces;
using GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;
using GestionAerolineas.src.Modules.Cities.Domain.ValueObject;
using GestionAerolineas.src.Modules.Cities.Infrastructure.Repository;
using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;
using GestionAerolineas.src.Modules.RoadTypes.Infrastructure.Repository;

namespace GestionAerolineas.src.Modules.Addresses.Application.Services;

public class AddressValidator : IAddressValidator
{
    private readonly RoadTypeRepository _roadTypeRepository;
    private readonly CityRepository _cityRepository;

    public AddressValidator(RoadTypeRepository roadTypeRepository, CityRepository cityRepository)
    {
        _roadTypeRepository = roadTypeRepository;
        _cityRepository = cityRepository;
    }

    public async Task ValidateRoadTypeExistsAsync(AddressRoadTypeId roadTypeId)
    {
        var exists = await _roadTypeRepository.ExistsAsync(RoadTypeId.Create(roadTypeId.Value));
        if (!exists)
            throw new Exception("El tipo de vía no existe");
    }

    public async Task ValidateCityExistsAsync(AddressCityId cityId)
    {
        var exists = await _cityRepository.ExistsAsync(CityId.Create(cityId.Value));
        if (!exists)
            throw new Exception("La ciudad no existe");
    }
}


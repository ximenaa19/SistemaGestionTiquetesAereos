using GestionAerolineas.src.Modules.Addresses.Application.Interfaces;
using GestionAerolineas.src.Modules.Addresses.Domain.Aggregate;
using GestionAerolineas.src.Modules.Addresses.Domain.Repositories;
using GestionAerolineas.src.Modules.Addresses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Addresses.Application.UseCases;

public class UpdateAddressUseCase
{
    private readonly IAddressRepository _repository;
    private readonly IAddressValidator _validator;

    public UpdateAddressUseCase(IAddressRepository repository, IAddressValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(
        int id,
        int roadTypeId,
        string roadName,
        string? number,
        string? complement,
        int cityId,
        string? postalCode)
    {
        var idVO = AddressId.Create(id);
        var roadTypeVO = AddressRoadTypeId.Create(roadTypeId);
        var roadNameVO = AddressRoadName.Create(roadName);
        var numberVO = AddressNumber.Create(number);
        var complementVO = AddressComplement.Create(complement);
        var cityVO = AddressCityId.Create(cityId);
        var postalVO = AddressPostalCode.Create(postalCode);

        await _validator.ValidateRoadTypeExistsAsync(roadTypeVO);
        await _validator.ValidateCityExistsAsync(cityVO);

        var entity = Address.Create(idVO, roadTypeVO, roadNameVO, numberVO, complementVO, cityVO, postalVO);
        await _repository.UpdateAsync(entity);
    }
}


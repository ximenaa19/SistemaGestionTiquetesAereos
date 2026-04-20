using GestionAerolineas.src.Modules.AircraftManufacturers.Application.Interfaces;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Repositories;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftManufacturers.Application.UseCases;

public class CreateAircraftManufacturerUseCase
{
    private readonly IAircraftManufacturerRepository _repository;
    private readonly IAircraftManufacturerValidator _validator;

    public CreateAircraftManufacturerUseCase(IAircraftManufacturerRepository repository, IAircraftManufacturerValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name, int countryId)
    {
        var nameVO = AircraftManufacturerName.Create(name);
        var countryIdVO = AircraftManufacturerCountryId.Create(countryId);

        await _validator.ValidateCountryExistsAsync(countryIdVO);
        await _validator.ValidateNameAsync(nameVO);

        var entity = AircraftManufacturer.CreateNew(nameVO, countryIdVO);

        await _repository.AddAsync(entity);
    }
}


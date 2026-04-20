using GestionAerolineas.src.Modules.AircraftManufacturers.Application.Interfaces;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Repositories;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftManufacturers.Application.UseCases;

public class UpdateAircraftManufacturerUseCase
{
    private readonly IAircraftManufacturerRepository _repository;
    private readonly IAircraftManufacturerValidator _validator;

    public UpdateAircraftManufacturerUseCase(IAircraftManufacturerRepository repository, IAircraftManufacturerValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string name, int countryId)
    {
        var idVO = AircraftManufacturerId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);
        if (existing is null)
            throw new Exception("El fabricante no existe");

        var nameVO = AircraftManufacturerName.Create(name);
        var countryIdVO = AircraftManufacturerCountryId.Create(countryId);

        await _validator.ValidateCountryExistsAsync(countryIdVO);
        await _validator.ValidateNameAsync(nameVO, idVO);

        var updated = AircraftManufacturer.Create(idVO, nameVO, countryIdVO);

        await _repository.UpdateAsync(updated);
    }
}


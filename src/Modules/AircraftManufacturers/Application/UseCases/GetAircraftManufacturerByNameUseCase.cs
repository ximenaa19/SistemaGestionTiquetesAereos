using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Repositories;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftManufacturers.Application.UseCases;

public class GetAircraftManufacturerByNameUseCase
{
    private readonly IAircraftManufacturerRepository _repository;

    public GetAircraftManufacturerByNameUseCase(IAircraftManufacturerRepository repository)
    {
        _repository = repository;
    }

    public Task<AircraftManufacturer?> ExecuteAsync(string name)
    {
        var nameVO = AircraftManufacturerName.Create(name);
        return _repository.GetByNameAsync(nameVO);
    }
}


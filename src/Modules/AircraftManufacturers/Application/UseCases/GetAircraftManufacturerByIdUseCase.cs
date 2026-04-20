using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Repositories;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftManufacturers.Application.UseCases;

public class GetAircraftManufacturerByIdUseCase
{
    private readonly IAircraftManufacturerRepository _repository;

    public GetAircraftManufacturerByIdUseCase(IAircraftManufacturerRepository repository)
    {
        _repository = repository;
    }

    public Task<AircraftManufacturer?> ExecuteAsync(int id)
    {
        var idVO = AircraftManufacturerId.Create(id);
        return _repository.GetByIdAsync(idVO);
    }
}


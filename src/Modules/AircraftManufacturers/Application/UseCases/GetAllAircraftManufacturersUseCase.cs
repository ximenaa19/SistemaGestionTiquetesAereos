using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Aggregate;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Repositories;

namespace GestionAerolineas.src.Modules.AircraftManufacturers.Application.UseCases;

public class GetAllAircraftManufacturersUseCase
{
    private readonly IAircraftManufacturerRepository _repository;

    public GetAllAircraftManufacturersUseCase(IAircraftManufacturerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<AircraftManufacturer>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


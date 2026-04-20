using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.Repositories;
using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftManufacturers.Application.UseCases;

public class DeleteAircraftManufacturerUseCase
{
    private readonly IAircraftManufacturerRepository _repository;

    public DeleteAircraftManufacturerUseCase(IAircraftManufacturerRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var idVO = AircraftManufacturerId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);
        if (existing is null)
            throw new Exception("El fabricante no existe");

        await _repository.DeleteAsync(existing);
    }
}


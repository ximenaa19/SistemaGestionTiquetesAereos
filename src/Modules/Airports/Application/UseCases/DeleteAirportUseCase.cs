using GestionAerolineas.src.Modules.Airports.Domain.Repositories;
using GestionAerolineas.src.Modules.Airports.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airports.Application.UseCases;

public class DeleteAirportUseCase
{
    private readonly IAirportRepository _repository;

    public DeleteAirportUseCase(IAirportRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(AirportId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}

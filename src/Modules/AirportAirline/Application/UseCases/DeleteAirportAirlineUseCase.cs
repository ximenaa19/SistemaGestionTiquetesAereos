using GestionAerolineas.src.Modules.AirportAirline.Domain.Repositories;
using GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AirportAirline.Application.UseCases;

public class DeleteAirportAirlineUseCase
{
    private readonly IAirportAirlineRepository _repository;

    public DeleteAirportAirlineUseCase(IAirportAirlineRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(AirportAirlineId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


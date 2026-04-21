using GestionAerolineas.src.Modules.RouteStops.Domain.Repositories;
using GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RouteStops.Application.UseCases;

public class DeleteRouteStopUseCase
{
    private readonly IRouteStopRepository _repository;

    public DeleteRouteStopUseCase(IRouteStopRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(RouteStopId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


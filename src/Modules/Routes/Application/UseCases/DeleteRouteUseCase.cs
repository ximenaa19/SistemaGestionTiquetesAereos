using GestionAerolineas.src.Modules.Routes.Domain.Repositories;
using GestionAerolineas.src.Modules.Routes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Routes.Application.UseCases;

public class DeleteRouteUseCase
{
    private readonly IRouteRepository _repository;

    public DeleteRouteUseCase(IRouteRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(RouteId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}


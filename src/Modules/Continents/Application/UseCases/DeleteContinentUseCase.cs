using GestionAerolineas.src.Modules.Continents.Application.Interfaces;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class DeleteContinentUseCase
{
    private readonly IContinentService _service;
    public DeleteContinentUseCase(IContinentService service) => _service = service;
    public Task<bool> HandleAsync(int id, CancellationToken ct = default) =>
        _service.DeleteAsync(id, ct);
}


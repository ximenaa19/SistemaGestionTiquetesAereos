using GestionAerolineas.src.Modules.Continents.Application.Interfaces;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class UpdateContinentUseCase
{
    private readonly IContinentService _service;
    public UpdateContinentUseCase(IContinentService service) => _service = service;
    public Task HandleAsync(int id, string name, CancellationToken ct = default) =>
        _service.UpdateAsync(id, name, ct);
}


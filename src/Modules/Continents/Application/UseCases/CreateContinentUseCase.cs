using GestionAerolineas.src.Modules.Continents.Application.Interfaces;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class CreateContinentUseCase
{
    private readonly IContinentService _service;
    public CreateContinentUseCase(IContinentService service) => _service = service;
    public Task HandleAsync(string name, CancellationToken ct = default) =>
        _service.CreateAsync(name, ct);
}


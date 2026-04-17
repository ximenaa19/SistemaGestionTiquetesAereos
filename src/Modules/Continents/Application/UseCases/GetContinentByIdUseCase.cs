using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class GetContinentByIdUseCase
{
    private readonly IContinentService _service;
    public GetContinentByIdUseCase(IContinentService service) => _service = service;
    public Task<Continent?> HandleAsync(int id, CancellationToken ct = default) =>
        _service.GetByIdAsync(id, ct);
}


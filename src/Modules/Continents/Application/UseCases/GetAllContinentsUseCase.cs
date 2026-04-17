using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class GetAllContinentsUseCase
{
    private readonly IContinentService _service;
    public GetAllContinentsUseCase(IContinentService service) => _service = service;
    public Task<IReadOnlyCollection<Continent>> HandleAsync(CancellationToken ct = default) =>
        _service.GetAllAsync(ct);
}


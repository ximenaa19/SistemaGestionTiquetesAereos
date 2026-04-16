using System.Threading.Tasks;
using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObjet;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class GetContinentByIdUseCase
{
    private readonly IContinentService _service;

    public GetContinentByIdUseCase(IContinentService service)
    {
        _service = service;
    }

    public Task<Continent?> ExecuteAsync(ContinentsId id)
    {
        return _service.GetByIdAsync(id);
    }
}

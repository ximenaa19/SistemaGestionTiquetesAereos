using System.Threading.Tasks;
using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObjet;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class UpdateContinentUseCase
{
    private readonly IContinentService _service;

    public UpdateContinentUseCase(IContinentService service)
    {
        _service = service;
    }

    public Task ExecuteAsync(ContinentsId id, ContinentName name)
    {
        return _service.UpdateAsync(id, name);
    }
}

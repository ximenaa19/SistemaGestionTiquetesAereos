using System.Threading.Tasks;
using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObjet;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class CreateContinentUseCase
{
    private readonly IContinentService _service;

    public CreateContinentUseCase(IContinentService service)
    {
        _service = service;
    }

    public Task ExecuteAsync(ContinentsId id, ContinentName name)
    {
        return _service.CreateAsync(id, name);
    }
}

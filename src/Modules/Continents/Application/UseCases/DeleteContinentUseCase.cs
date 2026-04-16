using System.Threading.Tasks;
using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObjet;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class DeleteContinentUseCase
{
    private readonly IContinentService _service;

    public DeleteContinentUseCase(IContinentService service)
    {
        _service = service;
    }

    public Task ExecuteAsync(ContinentsId id)
    {
        return _service.DeleteAsync(id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public sealed class GetAllContinentsUseCase
{
    private readonly IContinentService _service;

    public GetAllContinentsUseCase(IContinentService service)
    {
        _service = service;
    }

    public Task<List<Continent>> ExecuteAsync()
    {
        return _service.GetAllAsync();
    }
}

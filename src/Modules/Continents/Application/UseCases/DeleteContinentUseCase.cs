using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public class DeleteContinentUseCase
{
    private readonly IContinentRepository _repository;

    public DeleteContinentUseCase(IContinentRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var idVO = ContinentId.Create(id);

        var exists = await _repository.ExistsAsync(idVO);

        if (!exists)
            throw new Exception("El continente no existe");

        await _repository.DeleteAsync(idVO);
    }
}
using GestionAerolineas.src.Modules.Fares.Domain.Aggregate;
using GestionAerolineas.src.Modules.Fares.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Fares.Application.UseCases;

public class GetAllFaresUseCase
{
    private readonly IFareRepository _repository;

    public GetAllFaresUseCase(IFareRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Fare>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}


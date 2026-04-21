using GestionAerolineas.src.Modules.Fares.Domain.Aggregate;
using GestionAerolineas.src.Modules.Fares.Domain.Repositories;
using GestionAerolineas.src.Modules.Fares.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Fares.Application.UseCases;

public class GetFareByIdUseCase
{
    private readonly IFareRepository _repository;

    public GetFareByIdUseCase(IFareRepository repository)
    {
        _repository = repository;
    }

    public Task<Fare?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(FareId.Create(id));
    }
}


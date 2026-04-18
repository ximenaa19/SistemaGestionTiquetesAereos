using GestionAerolineas.src.Modules.CardTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardTypes.Domain.Repositories;

namespace GestionAerolineas.src.Modules.CardTypes.Application.UseCases;

public class GetAllCardTypesUseCase
{
    private readonly ICardTypeRepository _repository;

    public GetAllCardTypesUseCase(ICardTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CardType>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

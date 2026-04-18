using GestionAerolineas.src.Modules.CardTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardTypes.Application.UseCases;

public class GetCardTypeByNameUseCase
{
    private readonly ICardTypeRepository _repository;

    public GetCardTypeByNameUseCase(ICardTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<CardType?> ExecuteAsync(string name)
    {
        var nameVO = CardTypeName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}

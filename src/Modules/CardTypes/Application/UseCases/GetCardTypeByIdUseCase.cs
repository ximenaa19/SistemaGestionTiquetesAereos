using GestionAerolineas.src.Modules.CardTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CardTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardTypes.Application.UseCases;

public class GetCardTypeByIdUseCase
{
    private readonly ICardTypeRepository _repository;

    public GetCardTypeByIdUseCase(ICardTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<CardType?> ExecuteAsync(int id)
    {
        var idVO = CardTypeId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}

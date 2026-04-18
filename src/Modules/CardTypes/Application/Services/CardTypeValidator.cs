using GestionAerolineas.src.Modules.CardTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.CardTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardTypes.Application.Services;

public class CardTypeValidator : ICardTypeValidator
{
    private readonly ICardTypeRepository _repository;

    public CardTypeValidator(ICardTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(CardTypeName name, CardTypeId? currentId = null)
    {
        var normalizedCandidate = CardTypeName.Normalize(name.Value);
        var all = await _repository.GetAllAsync();

        foreach (var item in all)
        {
            if (currentId != null && item.Id.Value == currentId.Value)
                continue;

            if (CardTypeName.Normalize(item.Name.Value) == normalizedCandidate)
                throw new Exception("Ya existe un tipo de tarjeta con ese nombre");
        }
    }
}

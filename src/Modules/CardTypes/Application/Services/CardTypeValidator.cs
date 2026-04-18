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
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe un tipo de tarjeta con ese nombre");
    }
}

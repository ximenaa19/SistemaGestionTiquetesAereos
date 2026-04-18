using GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardTypes.Application.Interfaces;

public interface ICardTypeValidator
{
    Task ValidateNameAsync(CardTypeName name, CardTypeId? currentId = null);
}

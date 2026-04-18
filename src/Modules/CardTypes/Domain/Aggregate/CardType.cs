using GestionAerolineas.src.Modules.CardTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardTypes.Domain.Aggregate;

public class CardType
{
    public CardTypeId Id { get; private set; }
    public CardTypeName Name { get; private set; }

    private CardType(CardTypeId id, CardTypeName name)
    {
        Id = id;
        Name = name;
    }

    public static CardType Create(CardTypeId id, CardTypeName name)
    {
        return new CardType(id, name);
    }

    public static CardType CreateNew(CardTypeName name)
    {
        return new CardType(CardTypeId.CreateEmpty(), name);
    }
}

using GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardIssuers.Domain.Aggregate;

public class CardIssuer
{
    public CardIssuerId Id { get; private set; }
    public CardIssuerName Name { get; private set; }

    private CardIssuer(CardIssuerId id, CardIssuerName name)
    {
        Id = id;
        Name = name;
    }

    public static CardIssuer Create(CardIssuerId id, CardIssuerName name)
    {
        return new CardIssuer(id, name);
    }

    public static CardIssuer CreateNew(CardIssuerName name)
    {
        return new CardIssuer(CardIssuerId.CreateEmpty(), name);
    }
}

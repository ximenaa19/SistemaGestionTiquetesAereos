using GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardIssuers.Application.Interfaces;

public interface ICardIssuerValidator
{
    Task ValidateNameAsync(CardIssuerName name);
}

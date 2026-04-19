using GestionAerolineas.src.Modules.CardIssuers.Application.Interfaces;
using GestionAerolineas.src.Modules.CardIssuers.Domain.Repositories;
using GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CardIssuers.Application.Services;

public class CardIssuerValidator : ICardIssuerValidator
{
    private readonly ICardIssuerRepository _repository;

    public CardIssuerValidator(ICardIssuerRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(CardIssuerName name)
    {
        var existing = await _repository.GetByNameAsync(name);

        if (existing != null)
            throw new Exception("Ya existe un CardIssuer con ese nombre");
    }
}
